console.clear()
const EventEmitter = require('events'); // to send events (isn't it just a fancy way to call a func ?)
const express = require('express'); // i think this should be okay as webserver
const bodyParser = require('body-parser'); // to parse the post requests
const colors = require('colors');
const request = require('request');
const cors = require('cors')
const MongoClient = require('mongodb').MongoClient;
const assert = require('assert');
const jwt = require('jsonwebtoken');

// import config
const cfg = require('./config');
const { parse } = require('path');
// ====================================

// set api for webserver name
var api = express();
// ====================================

// DBSETUP
    // Connection URL
    // const url = 'mongodb://'+cfg.DBUrl+':'+cfg.DBPort;
    const url = 'mongodb://'+cfg.DBUser+':'+cfg.DBPwd+'@'+cfg.DBUrl+':'+cfg.DBPort+'?authMechanism=DEFAULT&authSource='+cfg.AuthDB

const opt = {'useNewUrlParser':true,'useUnifiedTopology':true }
var table;
MongoClient.connect(url,opt,function (err, client) {
    //assert.equal(null, err);
    if(err){Log.e("MONGO ERROR: "+String(err));process.exit(1);} // exit when db can't be reached
    Log.i("Connected successfully to DB");
    const db = client.db(cfg.DBName);
    userDB = db.collection('userBD');
    appDB = db.collection('appDB');
    banDB = db.collection('banDB');
});

// ====================================

// Body-parser
    // parse application/x-www-form-urlencoded
    api.use(bodyParser.urlencoded({ extended: false }))
    
    // parse application/json
    api.use(bodyParser.json())
// ====================================
    


// set EventEmitter + Listener
class MyEmitter extends EventEmitter {}
const event = new MyEmitter();
// ====================================
// FIRST DEFINE EVENT THEN CALL!
// event.emit('event',"hallo welt");
// event.on('event', (txt) => {
//     console.log(txt);
// });
// ====================================

// Logger helper
class Log{
    static d(txt){
        console.log("[\u001b[37mDEBUG\u001b[0m] "+String(txt))
    }
    static e(txt){
        console.log("[\u001b[31mERROR\u001b[0m] "+String(txt))
    }
    static w(txt){
        console.log("[\u001b[33mWARN\u001b[0m] "+String(txt))
    }
    static i(txt){
        console.log("[\u001b[32mINFO\u001b[0m] "+String(txt))
    }
}

// get args 
const Args = process.argv.slice(2);

// i try to reduce console spamm when not in debug mode.
var DEBUG = false;
if(Args.includes('--debug') || cfg.DEBUG){
    DEBUG = true;
}
// show path and method for debug purpose
if(DEBUG){
    api.use((req,res,next) => {
        Log.d(String('Got: '+req.method+" at :"+req.url).green)
        next();
    })
}



// ====================================
// ====================================
// ====================================

// Verify Token
function verifyToken(req, res, next) {
    // Get auth header value
    const bearerHeader = req.headers['authorization'];

    // Check if bearer is undefined
    if (typeof bearerHeader !== 'undefined') {
        // Split at the space
        const bearerToken = bearerHeader;
        // set the token
        req.token = bearerToken;
        // Next middleware
        next();
    } else {
        // Forbidden
        res.sendStatus(403);
    }

}

// ====================================
// ====================================
// ====================================


api.get('/', function (req, res) {
    res.set('Content-Type', 'application/json');
    request('https://uselessfacts.jsph.pl/random.json?language=de',(err,resp,body) => {
        if(err){ return res.status(500).send({'error':'Request failed'})}
        data = JSON.parse(body)
        res.send({'fact':data['text']})
    })
});



api.post('/app.login', (req, res) => {
    let data = req.body;
    appDB.countDocuments({'_id':parseInt(data.id)},limit=1,(err,DocCount) => { // is there even an app using that id? // is it worth looging for it ?
        if(DocCount == 0){
            res.sendStatus(403)
        }else{
            //appdata = appDB.findOne()
            appDB.findOne({'_id':parseInt(data.id)}, (err, appdata) => { // find the app by id
                if (err){res.status(500).send({'error':true,'msg':err});Log.e("ERROR IN APP.LOGIN: "+err)} // error handling

                if(data.name == appdata.name && data.key == appdata.key){ // test if login is correct 
                    jwt.sign({ app: appdata }, cfg.JWTKey, { expiresIn: '86400s' }, (err, token) => { // sign the appdata to a token 
                        res.json({
                            token: token // send the signed token to client
                        });
                    });
                }else{
                    res.status(403).send({'error':true,'msg':'wrong_data'})
                }
            });
        }    
    });
});


api.post('/user.new',verifyToken, (req,res) => {
    res.set('Content-Type', 'application/json');
    jwt.verify(req.token, cfg.JWTKey, (err, authData) => {
        if (err) {
            Log.e(err)
            res.sendStatus(403); // wrong token
        } else {               
            if(req.body.user !== "undefined"){
                userDB.countDocuments({'_id':String(req.body.user)},limit=1,(err,DocCount) => {
                    banDB.countDocuments({'_id':String(req.body.user)},limit=1,(err,BanDocCount) => {
                        if(BanDocCount == 0){
                            if (err){res.status(500).send({'error':true,'msg':err});Log.e("ERROR IN USER.NEW: "+err)}

                            if(DocCount == 0){
                                var input = req.body
                                // Use connect method to connect to the server
                                // | DiscordID | Money | PMoney | banned | bot |
                                data = {}
                                data._id = String(input.user); // just gonna save them as String because i cant handle Int right at the moment ... gonna fix this asap!
                                data.Money = cfg.startBlue;
                                data.PMoney = cfg.startRP;
                                data.banned = false;
                                data.bot = false;
                                
                                if(DEBUG){  // show posted data for debug purpose
                                    Log.d(JSON.stringify(data))
                                }
            
                                userDB.insertOne(data, function (err, dbres) {
                                if (err){Log.e(err);res.sendStatus(500)};
            
                                res.status(200).send({ 'error': false })
                                });
                            }else{
                                res.status(403).send({'error':true,'msg':'user_exists'})
                            } 
                        }else{
                            res.status(403).send({'error':true,'msg':'user_banned'})
                        }
                    });
                })
                
            }else{
                res.status(400).send({'error':true,'msg':'no_id_provided'})
            }
        }
    });
})

api.post('/user.ban',verifyToken, (req,res) => {
    jwt.verify(req.token, cfg.JWTKey, (err, authData) => {
        if (err) {Log.e(err);res.sendStatus(403); // wrong token
        } else {
            if(req.body.user !== "undefined"){
                userDB.countDocuments({'_id':String(req.body.user)},limit=1,(err,DocCount) => {
                    if(DocCount != 0){
                        userDB.removeOne({'_id':String(req.body.user)},(err,dbres) => { // try to remove user
                            if (err){Log.e("ERROR IN USER.BAN: "+err)}
                        });

                        banDB.insertOne({'_id':String(req.body.user)},(err,dbres) =>{
                            if(err){
                                Log.e("ERROR IN USER.BAN: "+err)
                                res.status(500).send({'error':true,'msg':'ban_failed'})
                            }
                        });
                    }else{
                        res.status(403).send({'error':true,'msg':'no_such_user'})
                    }
                });
            }else{
                res.status(400).send({'error':true,'msg':'no_id_provided'})
            }
        }
    });
});

api.post('/user.pay',verifyToken,(req,res) => {
    jwt.verify(req.token, cfg.JWTKey, (err, authData) => {
        if (err) {Log.e(err);res.sendStatus(403); // wrong token
        }else{
            if(req.body.from !== "undefined" && req.body.to !== "undefined" && req.body.type !== "undefined" && req.body.amount !== "undefined"){
                userDB.countDocuments({'_id':String(req.body.from)},limit=1,(err,DocCount) => { // does the user exist ?
                    if(DocCount != 0){ // Exist: yes
                        banDB.countDocuments({'_id':String(req.body.from)},limit=1,(err,BanDocCount) => { // is he banned
                            if(BanDocCount == 0){ // banned: no
                                // prepare vars
                                let from = String(req.body.from)
                                let to = String(req.body.to)
                                let type = String(req.body.type.toLowerCase())
                                let amount = parseInt(req.body.amount)

                                if (typeof(amount) === 'undefined'){
                                    res.status(403).send({'error':true,'msg':'Invalid_value'})
                                }else if(type == "n"){

                                    if(from != "3406"){
                                        money = parseInt(userDB.findOne({'_id':from},{money:1})) // get the current money
                                        userDB.updateOne({'_id':from},{$set: {'money':parseInt(money - amount)}} )
                                    }
                                    
                                    userDB.findOne({'_id':to},(err, user) => {
                                        tmoney = parseInt(user['Money'])

                                        userDB.updateOne({'_id':to},{$set: {'Money':parseInt(tmoney + amount) }},(err,ures) =>{
                                            if (err){res.status(403).send({'error':true,'msg':"ERROR IN USER.PAY: "+err});Log.e("ERROR IN USER.PAY: "+err)}                               
                                            res.sendStatus(200)
                                        } )
                                        
                                    });
                                    
                                }else{
                                    res.status(403).send({'error':true,'msg':'invalid_type'})
                                }
                            }else{ // banned: yes
                                res.status(403).send({'error':true,'msg':'user_banned'})
                            }
                        });
                    }else{ // Exist: no
                        res.status(403).send({'error':true,'msg':'no_such_user'})
                    }
                });

            }else{
                res.status(400).send({'error':true,'msg':'missing_data'});
            }
        }

    });
});

api.post('/user.get',verifyToken,(req,res) => {
    jwt.verify(req.token, cfg.JWTKey, (err, authData) => {
        if (err) {Log.e(err);res.sendStatus(403); // wrong token
        }else{
            if(req.body.user !== "undefined" && req.body.to !== "undefined" && req.body.type !== "undefined" && req.body.amount !== "undefined"){
                userDB.countDocuments({'_id':String(req.body.user)},limit=1,(err,DocCount) => { // does the user exist ?
                    if(DocCount != 0){ // Exist: yes
                        userDB.findOne({'_id': String(req.body.user)},(err,doc) => {
                            res.send(doc)
                        })
                    }
                });
            }
        }
    });
});

api.listen(port=cfg.PORT,hostname=cfg.HOSTNAME, function () {
    if(DEBUG){
        Log.d('Server started on port: '+String(cfg.PORT).green+", and is listening on: "+cfg.HOSTNAME.green)
    }else{
        Log.i("Running".green);
    }
});