const electron = require('electron');
const url = require('url');
const path = require('path');
const fs = require('fs');
const download = require('download');
var request = require('request');


const {app, BrowserWindow, Menu, ipcMain} = electron;

let mainWindow;
let addWindow;


// if (fs.existsSync('assets')) {
    // download('http://unicorn.com/foo.jpg', 'dist').then(() => {
    //     console.log('done!');
    // });
// }



// Listen for app to be ready
app.on('ready', function(){
    // Create Window
    mainWindow = new BrowserWindow({
        width: 1024,
        height: 576,
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
        mainWindow.webContents.send('error:show','Setting Protocoll to http.')
    }

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
        throw err
    }
        var headers = res.headers
        var statusCode = res.statusCode
        console.log('headers: ', headers)
        console.log('statusCode: ', statusCode)
        console.log('body: ', body)
    })



    // request.post({ 
    //     url: server+'/api/login/', 
    //     body: loginData,
    //     json: true
    // },
    //     function (err, httpResponse, body){
    //         // console.log(httpResponse.statusCode) 
    //         console.log(server+'/api/login/')
    //     })
})


// menu template
const mainMenuTemplate = [
    {
        label: 'File',
        submenu:[
            {
                label: 'Quit',
                accelerator: process.platform == 'darwin' ? 'Command+Q' : 'Ctrl+Q',
                click(){
                    app.quit();
                }
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