var currentUser = '';

function register() {
    var username = document.getElementById('username').value;
    if (username.trim() === '') {
        alert('Please enter your name.');
    } else {
        // Store the current username
        currentUser = username;

        // Hide registration section
        document.querySelector('.container').style.display = 'none';

        // Show text editor section
        document.getElementById('textEditor').style.display = 'block';

        // Display current username
        document.getElementById('currentUserDisplay').innerText = 'Current User: ' + currentUser;

        // Clear register input box
        document.getElementById('username').value = '';
    }
}

function updateStats() {
    var text = document.getElementById('textInput').value;
    var wordCount = text.trim().split(/\s+/).length;
    var letterCount = text.replace(/\s/g, '').length;
    var numberCount = text.replace(/[^0-9]/g, '').length;

    document.getElementById('wordCount').innerText = wordCount;
    document.getElementById('letterCount').innerText = letterCount;
    document.getElementById('numberCount').innerText = numberCount;
}

function saveText() {
    var text = document.getElementById('textInput').value;
    var fileName = document.getElementById('fileName').value;

    if (fileName.trim() === '') {
        alert('Please enter a file name.');
        return;
    }

    var savedTextDiv = document.createElement('div');
    savedTextDiv.classList.add('saved-text');

    savedTextDiv.innerHTML = `
        <h4>File Name: ${fileName}</h4>
        <p><strong>Saved Text:</strong></p>
        <div>${text}</div>
        <p><strong>Word Count:</strong> <span id="wordCount">${text.trim().split(/\s+/).length}</span></p>
        <p><strong>Letter Count:</strong> <span id="letterCount">${text.replace(/\s/g, '').length}</span></p>
        <p><strong>Number Count:</strong> <span id="numberCount">${text.replace(/[^0-9]/g, '').length}</span></p>
    `;

    document.getElementById('savedFiles').appendChild(savedTextDiv);

    // Clear input fields after saving
    document.getElementById('fileName').value = '';
    document.getElementById('textInput').value = '';

    // Update stats display
    updateStats();
}
