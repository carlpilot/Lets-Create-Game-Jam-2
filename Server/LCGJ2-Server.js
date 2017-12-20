
var http = require('http');
var fs = require('fs');
var port = 4356;

var dataFile = "data.txt";

console.log('Starting server...');

var highScores = {};
var scoresList = [];

loadData ();
http.createServer(function(req, res) {
	console.log('  > Received request: ' + req.url.toString());
	res.end(getData(req.url.toString()));
	saveData(getScores(-1));
}).listen(port);

console.log("Server running");

function getData (url) {
	var query = url.substring(1); // To remove first slash
	console.log('  > ' + query);
	var queryElements = query.split('$');

	var command = queryElements[0].toUpperCase();
	if(command == 'SETSCORE') {
		console.log('Setting a score.');
		highScores[queryElements[1]] = parseInt(queryElements[2]);
		scoresList.push(queryElements[2]);
		return "Set score.";
	} else if (command == 'GETSCORES') {
		console.log('Getting all scores.');
		return getScores (queryElements[1]);
	} else {
		return "Could not interpret command";
	}
}

function loadData () {
	if(fs.existsSync(dataFile)) {
		fs.readFile(dataFile, 'utf8', function(err, data) {
			if(err) throw err;
			console.log('Data loading step 1 complete');
			loadDataStep2(data);
		});
	} else {
		console.log('Data file does not exist. No data will be loaded.');
	}
}

function loadDataStep2 (data) {
	var items = data.split('\n');
	console.log('Loading items: ' + items);
	//console.log('items = ' + items);
	for(var i = 0; i < items.length; i++) {
		var itemElements = items[i].split('$$');
		// like LEV2_PlayerName = 25
		highScores['LEV' + itemElements[2] + '_' + itemElements[0]] = parseInt(itemElements[1]);
		scoresList.push(itemElements[1]);
	}
	console.log('Data loading step 2 complete');
}

function saveData (data) {
	fs.writeFile(dataFile, data, function(err) {
		if(err) throw err;
		console.log('Saved data file');
	});
}

function getScores (level) {
	var output = "";

	//console.log('scoresList = ' + scoresList);

	var sortedScores = scoresList;
	sortedScores.sort(function (a,b) { return a - b; });

	var highScoresCopy = {};
	for(var key in highScores) {
		highScoresCopy[key] = highScores[key];
	}

	for(var i = 0; i < sortedScores.length; i++) {
		//console.log('sortedScores[' + i + '] = ' + sortedScores[i]);
		for(var key in highScoresCopy) {
			if(highScoresCopy[key] == sortedScores[i]) {
				highScoresCopy[key] = null;
				var x = key + '$$' + sortedScores[i] + '\n';
				if(x != key + '$$' + 'undefined' + '\n') {

					if(level == -1 || key.includes('LEV' + level)) {
						output += x;
					}

				}
				break;
			}
		}
	}

	return output.substring(0, output.length - 1); // remove final \n
}




