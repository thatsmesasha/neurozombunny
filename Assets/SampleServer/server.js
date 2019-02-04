var WebSocketServer = require('websocket').server;
var http = require('http');

var server = http.createServer(function(request, response) {
  // process HTTP request. Since we're writing just WebSockets
  // server we don't have to implement anything.
});
server.listen(4242, function() {
  console.log("Listening on 4242");
});

// create the server
wsServer = new WebSocketServer({
  httpServer: server
});

function sleep(ms){
    return new Promise(resolve=>{
        setTimeout(resolve,ms)
    })
}

// WebSocket server
wsServer.on('request', function(request) {
  var connection = request.accept(null, request.origin);

  // This is the most important callback for us, we'll handle
  // all messages from users here.
  connection.on('message', function(message) {
    if (message.type === 'utf8') {
      // process WebSocket message
    }
  });

  connection.on('close', function(connection) {
    // close user connection
  });

  let i = 0
  const spells = ["Lightning", "Another"];
  (async () => {
    while (true) {
      connection.send(spells[i]);
      await sleep(2000);
      i = (i + 1) % spells.length;
    }
  })();
});
