"use strict"

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

console.log("connection done");

document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    li.textContent = `${user} : ${message} `;
    document.getElementById("messagesList").appendChild(li);
})

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    console.log(`${user}`);
    var message = document.getElementById("messageInput").value;
    console.log(`${message}`);
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});