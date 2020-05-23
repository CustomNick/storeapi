function commentsByItem(id, role) {
    name = "";
    disp = "d-none";
    if (role == "admin")
        disp = "";
    $.ajax(
        {
            type: 'GET',
            async: false,
            url: `/api/item/${id}`,
            contentType: 'application/json; charset=utf-8',
            success: function (data, textStatus) {
                name = data.name + "";
                console.log(name);
            }
        })
    $.ajax(
        {
            type: 'GET',
            url: `/api/message/${id}`,
            contentType: 'application/json; charset=utf-8',
            success: function (data, textStatus) {
                var comms = "";
                data.forEach(function(mes){
                    comms += `<div id="comment" class="mx-4 my-2 border px-3 py-3"><h3>${mes.name}</h3><p>${mes.text}</p><button class="btn btn-outline-success btn-block dltCmnt ${disp}" id="${mes.id}">Delete comment</button></div>`
                });
                sessionStorage.removeItem("name");
                $("#content").html(`<div class="row justify-content-md-center col-10"><div class=""col-12">
                    <div class="text-center col-12">
                        <h1 class="card-title">Comments for item "${name}"</h1>
                    </div>
                    <div id="comments">${comms}</div>
                    <div id="writeComment">
                        <form name="writeComment">
                            <div class="form-group">
                                <label for="text">Input comment</label>
                                <input class="form-control" name="text" id="${id}"/>
                            </div>
                        </form>
                        <button class="btn btn-outline-success btn-block" id="sendComment">Send comment</button>
                    </div>
                    </div>`);
            }
        });
}

function sendComment(text, id, itemId) {
    token = sessionStorage.getItem("token");
    if (token != null) {
        var roles = getRolesById(id);
        var name = getNameById(id);
        console.log(name);
        if (roles.indexOf("admin") in roles)
            role = "admin";
        else
            role = "user";
        $.ajax(
            {
                type: 'POST',
                url: `/api/message`,
                contentType: 'application/json; charst=utf-8',
                beforeSend: function (request) {
                    request.setRequestHeader("Authorization", `Bearer ${sessionStorage.getItem("token")}`);
                },
                dataType: 'json',
                data: `{ 
                    "text": "${text}",
                    "name": "${name}",
                    "itemid": "${itemId}"
                }`,
                success: function (data, textStatus) {
                    commentsByItem(itemId, role);
                },
                error: function (data, textStatus) {
                    $.ajax(
                        {
                            type: 'POST',
                            url: `/api/auth/refreshtoken`,
                            contentType: 'application/json; charst=utf-8',
                            dataType: 'json',
                            data: `{ 
                                "accesstoken": "${sessionStorage.getItem("token")}",
                                "refreshToken": "${sessionStorage.getItem("refreshToken")}"
                                }`,
                            success: function (data, textStatus) {
                                sessionStorage.setItem("token", data.data.accessToken);
                                sessionStorage.setItem("refreshToken", data.data.refreshToken);
                                console.log(text, name, itemId);
                                sendComment(text, id, itemId);
                            },
                            error: function (data, textStatus) {
                                $("#content").html(createLoginForm());
                            }
                        })
                }
            })
    }
    else {
        $("#content").html(createLoginForm());
    }
}

function deleteComment(id, itemId) {
    
    $.ajax(
        {
            type: "DELETE",
            url: `/api/message/${id}`,
            dataType: "json",
            success: function (data, textStatus) {
                commentsByItem(itemId, "admin");
            }
        });
}