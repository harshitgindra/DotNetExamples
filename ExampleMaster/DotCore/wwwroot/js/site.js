"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/taskHub").build();

connection.on("TaskUpdate", function (message) {
    var li = document.createElement("li");
    li.textContent = message;
    document.getElementById("tasks").appendChild(li);
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("start-task").addEventListener("click", function (event) {
    $.ajax({
        url: '/Home/StartTask',
        type:'POST'
    }).done(function (result) { });
    event.preventDefault();
});

document.getElementById("stop-task").addEventListener("click", function (event) {
    $.ajax({
        url: '/Home/StopTask',
        type: 'POST'
    }).done(function (result) { });
    event.preventDefault();
});
