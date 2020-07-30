$(document).ready(function () {
    $(window).keydown(function (event) {
        if (event.keyCode == 13) {
            event.preventDefault();
            return false;
        }
    });
});

$('img').on('dragstart', function (event) { event.preventDefault(); });

function getRandomInt(min, max) {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

// === BACKGROUND (CURRENTLY HARDCODED) === //
/* */   var gif = 7//getRandomInt(1,7);    /* */
//==========================================//
$('body').addClass("video" + gif);

$('input:checkbox').change(function () {
    if ($(this).is(":checked")) {
        $('body').removeClass("video" + gif);
    } else {
        $('body').addClass("video" + gif);
    }
});

document.querySelector('#loginForm').addEventListener('submit', (e) => {
    e.preventDefault();
    data = {}
    data.name = encodeURIComponent(document.querySelector('#nickname').value);
    data.pass = document.querySelector('#password').value;
    data.server = document.querySelector('#server').value;

    ipcRenderer.send('login:send', data);

    $('#loading').removeClass('hide');
})

// get error msg from frame and display it.
ipcRenderer.on('error:show', (e, msg) => {
    $('#loading').addClass('hide');
    $('#lerror').html('<h6 style="color:red;">' + msg + "</h6>")
    $('#lerror').removeClass('hide');
    setTimeout(() => {
        $('#lerror').addClass('hide');
    }, 10000);
})