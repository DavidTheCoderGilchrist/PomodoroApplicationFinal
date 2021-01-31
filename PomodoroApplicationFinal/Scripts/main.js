﻿var start = document.getElementById('start');
var stop = document.getElementById('stop');
var reset = document.getElementById('reset');

var wm = document.getElementById('w_minutes');
var ws = document.getElementById('w_seconds');

var bm = document.getElementById('b_minutes');
var bs = document.getElementById('b_seconds');

var points = document.getElementById('points');

//store a reference to a timer variable
var startTimer;

start.addEventListener('click', function () {

    if (startTimer != undefined) {
        alert("Timer is already running")
    }

    else {
        startTimer = setInterval(timer, 1000)
    }


})

reset.addEventListener('click', function () {
    wm.innerText = 25;
    ws.innerText = "00";

    bm.innerText = 5;
    bs.innerText = "00";

    document.getElementById('points').innerText;
    stopInterval()
    startTimer = undefined;
})

stop.addEventListener('click', function () {
    stopInterval()
    startTimer = undefined;
})



//Start Timer Function
function timer() {
    //Work Timer Countdown
    if (ws.innerText != 0) {
        ws.innerText--;
    } else if (wm.innerText != 0 && ws.innerText == 0) {
        ws.innerText = 59;
        wm.innerText--;
    }

    //Break Timer Countdown
    if (wm.innerText == 0 && ws.innerText == 0) {
        if (bs.innerText != 0) {
            bs.innerText--;
        } else if (bm.innerText != 0 && bs.innerText == 0) {
            bs.innerText = 59;
            bm.innerText--;
        }
    }

    //Increment Points by 5 if one full cycle is completed
    if (wm.innerText == 0 && ws.innerText == 0 && bm.innerText == 0 && bs.innerText == 0) {
        wm.innerText = 25;
        ws.innerText = "00";

        bm.innerText = 5;
        bs.innerText = "00";

        document.getElementById('points').innerText++;
        document.getElementById('points').innerText++;
        document.getElementById('points').innerText++;
        document.getElementById('points').innerText++;
        document.getElementById('points').innerText++;

        stopInterval()
        startTimer = undefined;

    }

}

//End Timer Function
function endTimer() {
    wm.innerText = 25;
    ws.innerText = "00";

    bm.innerText = 5;
    bs.innerText = "00";
}

//Stop Timer Function
function stopInterval() {
    clearInterval(startTimer);
}


//bank.addEventListener('click', function () {

//    document.getElementById('points').innerText = 0;


//})