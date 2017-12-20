
var http = require('http');
var fs = require('fs');
var port = 4356;

var dataFile = "data.txt"

console.log('Starting server...');

loadData ();
http.createServer(function(req, res) {
	console.log('  > Received request: ' + req.url.toString());
	res.end(getData(req.url.toString()));
}).listen(port);

console.log("Server running");

var highScores = {};

function getData (url) {
	var query = url.substring(1); // To remove first slash
	console.log(query);
}

function loadData () {
	if(fs.existsSync(dataFile)) {
		fs.readFile(dataFile, 'utf8', function(err, data) {
			if(err) throw(err);
			console.log('Loaded data file');
			console.log(data);
		});
	} else {
		console.log('Data file does not exist. No data will be loaded.');
	}
}
