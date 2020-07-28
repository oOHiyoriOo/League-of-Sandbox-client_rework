console.clear()

const electron = require('electron');
const url = require('url');
const path = require('path');
const fs = require('fs');
const download = require('download');
const request = require('request');
const urlencode = require('urlencode');

const {app, BrowserWindow, Menu, ipcMain} = electron;

let mainWindow;

////////////////////////////
// INIT
////////////////////////////
// 1. check if appdata dir ist installed
var cfg = {};
let AppDataFolder = process.env.APPDATA+"/LeagueSandbox"
let AppDataConfig = process.env.APPDATA+"/LeagueSandbox/config.json"
try {
    if (!fs.existsSync(AppDataFolder)) {   
        fs.mkdirSync(AppDataFolder);
    }
} catch (e) {
    throw "AppData check Error"
}
// 2. Let's check for a config // create one if needed.
if (fs.existsSync(AppDataConfig)) {
    cfg = JSON.parse(fs.readFileSync(AppDataConfig,encoding='utf-8'))
    console.log(cfg)
}else{
    config = '{"screenx": 1024,"screeny": 576}'
    fs.writeFile(AppDataConfig, config,encoding='utf-8', function (err) {
        if (err) throw "Config Creation error!: "+err
    });
    cfg = JSON.parse(fs.readFileSync(AppDataConfig,encoding='utf-8'))
    console.log(cfg)
}


//fileData = fs.readFileSync(process.env.APPDATA + '/folder/file.txt',{encoding:'utf8'});

////////////////////////////////////
//Helper Functions
///////////////////////////////////
function configSave(){
    config = JSON.stringify(cfg)
    fs.writeFile(AppDataConfig, config,encoding='utf-8', function (err) {
        if (err) throw "Config Creation error!: "+err
    });
}




// if (fs.existsSync('assets')) {
    // download('http://unicorn.com/foo.jpg', 'dist').then(() => {
    //     console.log('done!');
    // });
// }

// Listen for app to be ready
app.on('ready', function(){
    // Create Window
    mainWindow = new BrowserWindow({
        width: cfg.screenx,
        height: cfg.screeny,
        frame: false,
        resizable: false,
        webPreferences:{
            nodeIntegration: true
        }
    });
    //load html file (UI)
    mainWindow.loadURL(url.format({
        pathname: path.join(__dirname, 'loginWindow.html'),
        protocol: 'file',
        slashes: true
    }));
    //quit app on exizt
    mainWindow.on('closed',function(){
        app.quit();
    })
    // Build menu from Template
    const mainMenu = Menu.buildFromTemplate(mainMenuTemplate);
    // isert menu
    Menu.setApplicationMenu(mainMenu);
});




// catch login data
ipcMain.on('login:send',function(e, loginData){
    console.log("Received: "+ JSON.stringify(loginData))
    
    if(loginData.server.includes("http") || loginData.server.includes('https')){
        server = loginData.server
    }else{
        server = "http://"+loginData.server
        // mainWindow.webContents.send('error:show','Setting Protocoll to http.')
    }

    loginData.name = urlencode(loginData.name)

    var url = server+'/api/login/'
    var options = {
        method: 'post',
        body: loginData,
        json: true,
        url: url
    }

    request(options, function (err, res, body) {
        if (err) {
            console.error('error posting json: ', err)
            mainWindow.webContents.send('error:show','Connection error: '+err)
        }else{
            var headers = res.headers
            var statusCode = res.statusCode
            // console.log('headers: ', headers)
            // console.log('statusCode: ', statusCode)
            // console.log('body: ', body)
            console.log(body)
            // var response = JSON.parse(body)
            // if(response.error == true){
            //     mainWindow.webContents.send('error:show',response.msg)
            // }
        }
    })
})


// menu template
const mainMenuTemplate = [
    {
        label: 'Options',
        submenu:[
            {
                label: 'Quit',
                accelerator: process.platform == 'darwin' ? 'Command+Q' : 'Ctrl+Q',
                click(){
                    app.quit();
                }
            },
            {
                label: 'Resize',
                submenu: [
                    {
                        label: '1024 x 576',
                        click(){
                            mainWindow.setMinimumSize(1024,576)
                            mainWindow.setSize(1024,576)
                            cfg.screenx = 1024;
                            cfg.screeny = 576;
                            configSave();
                        }
                    },
                    {
                        label: '1280 x 720',
                        click(){
                            mainWindow.setMinimumSize(1280,720)
                            mainWindow.setSize(1280,720)   
                            cfg.screenx = 1280;
                            cfg.screeny = 720;
                            configSave();                         
                        }
                    },
                    {
                        label: '1600 x 900',
                        click(){
                            mainWindow.setMinimumSize(1600,900)
                            mainWindow.setSize(1600,900)     
                            cfg.screenx = 1600;
                            cfg.screeny = 900;
                            configSave();                       
                        }
                    }
                ]
            }
        ]
    }
];

// fix mac menu error
if(process.platform == 'darwin'){
    mainMenuTemplate.unshift({});
}

// add dev tools if not in production
if(process.env.NODE_ENV !== 'production'){
    mainMenuTemplate.push({
        label:'Dev Tools',
        submenu:[
            {
                label:'Dev Tools',
                accelerator: 'F12',
                click(item,focusedWindow){
                    focusedWindow.toggleDevTools();
                }
            },
            {
                role:'reload',
                accelerator: 'F5'
            }
        ]
    });
}