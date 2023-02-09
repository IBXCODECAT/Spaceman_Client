handlers.GetUserReadOnlyData = function(args, context)
{
    var playerDataResponse = server.GetUserReadOnlyData
    (
        {
            "PlayFabId" : currentPlayerId,
            "Keys" : ["discord_member", "enable_developer_tools", "is_early", "is_staff"]
        }
    );
    
    return playerDataResponse.Data;
}

handlers.DiscordTokenExchange = function(args, context)
{
    const client_id = '988833332445978624';
    const client_secret = 'you don\'t get to see this sorry :(';
    const redirect_URI = 'http://localhost:8080';
    
    //CloudScript (Legacy)
    var url = "https://discord.com/api/v10";
    var method = "post";
    var contentBody = "grant_type=authorization_code";
    var contentType = "application/x-www-form-urlencoded";
    
    var headers = {};
    headers["client_id"] = client_id;
    headers["client_secret"] = client_secret;
    
    var tokenResponse = http.request(url, method, contentBody, contentType, headers);
    
    
    return args.code;
}
