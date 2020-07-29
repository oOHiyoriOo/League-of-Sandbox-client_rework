// menu template
const mainMenuTemplate = [
    {
        label: 'File',
        submenu:[
            {
                label: 'Add Item',
                click(){
                    createAddWindow();
                }
            },
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

// Handle Add Item Window
function createAddWindow(){
    // Create Window
    addWindow = new BrowserWindow({
        width:300,
        height:200,
        title:'Add Items',
        frame: false,
        resizable: false,
        webPreferences:{
            nodeIntegration: true
        }
    });
    //load html file (UI)
    addWindow.loadURL(url.format({
        pathname: path.join(__dirname, 'addWindow.html'),
        protocol: 'file',
        slashes: true
    }));

    // hanfdle Garbage
    addWindow.on('closed',function(){
        addWindow = null
    })
}