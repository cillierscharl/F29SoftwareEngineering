function ReceiveServerData(data) {
    var response = JSON.parse(data);
    window[response.ActionReturned](response);
}

function SendCallback(data) {
    CallServer(data, '');
}

function buildCallback(name, operation, parameters) {
    var callbackObject = {
        'ActionRequested':name,
        'Operation':operation,
        'Parameters':parameters
    }
    return callbackObject;
}
