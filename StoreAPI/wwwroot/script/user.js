function LogIn(email, pass)
{
    console.log(email, pass);
    $.ajax(
        {
            type: 'POST',
            url: '/api/auth/login',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: `{ 
                "email": "${email}",
                "Password": "${pass}"
            }`,
            success: function(data, textStatus)
            {
                sessionStorage.setItem("token", data.data.accessToken);
                sessionStorage.setItem("refreshToken", data.data.refreshToken);
                onStart();
                var token = sessionStorage.getItem("token");
            }
        });
}

function Reg(email, name, pass)
{
    $.ajax(
        {
            type: 'POST',
            url: '/api/auth/register',
            dataType : "json",
            contentType: "application/json; charset=utf-8",
            data: `{ 
                "email": "${email}",
                "name": "${name}",
                "Password": "${pass}"
            }`,
            success: function (data, textStatus)
            {
                sessionStorage.setItem("token", data.data.accessToken);
                sessionStorage.setItem("refreshToken", data.data.refreshToken);
                onStart();
            }
        });
    $.ajax(
        {
            type: 'POST',
            url: '/api/user/user',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: `{ 
                "email": "${email}",
                "name": "${name}"
            }`
        })
}

function parseJwt(token) {
    token = token;
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
};

function time() {
    return parseInt(new Date().getTime() / 1000)
}

function getNameById(id) {
    var name = "";
    $.ajax(
        {
            type: 'GET',
            async: false,
            url: `/api/user/${id}`,
            contentType: 'application/json; charset=utf-8',
            success: function (data, textStatus) {
                console.log(data.name);
                name = data.name + "";
            }
        })
    return name;
}

function getRolesById(id) {
    var roles = [];
    $.ajax(
        {
            type: 'GET',
            async: false,
            url: `/api/user/role/${id}`,
            contentType: 'application/json; charset=utf-8',
            success: function (data, textStatus) {
                console.log(data);
                data.forEach(function (item) {
                    roles.push(item + "");
                })
            }
        });
    return roles;
}