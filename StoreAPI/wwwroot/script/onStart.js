$(document).ready(onStart());

function stopIt()
{
    event.preventDefault();
}

function onStart()
{
    if (sessionStorage.getItem("token") != null){
        $("#header").html(`
        <div class="col-10 bg-dark text-white">
            <a class="navbar-brand">Store for homework</a>
        </div>
        <div class="col-1 bg-dark text-white">
            You logged in!
        </div>
        <div class="col-1 bg-dark text-white">
            <button style="cursor: pointer;" id="logout" class="btn btn-link">
                Log out
            </button>
        </div>`);
        roles = getRolesById(parseJwt(sessionStorage.getItem("token")).sub);
        if (roles.indexOf("admin") in roles) {
            getControlBtns("admin");
            getAllItems("admin");
            getAllCategories();
        }
        else {
            getControlBtns("user");
            getAllItems("user");
            getAllCategories();
        }
    }
    else{
        $("#header").html(`
        <div class="col-10 bg-dark text-white">
            <a class="navbar-brand">Store for homework</a>
        </div>
        <div class="col-1 bg-dark text-white">
            <button style="cursor: pointer;" id="login" class="btn btn-link">
                Log in
            </button>
        </div>
        <div class="col-1 bg-dark text-white">
            <button style="cursor: pointer;" id="reg" class="btn btn-link">
                Sign up
            </button>
        </div>`);
        getControlBtns("user");
        getAllItems("user");  
        getAllCategories(); 
    }
    //console.log(parseJwt(sessionStorage.getItem("token")));
}

function getControlBtns(role) {
    if (role == "admin")
        disp = '';
    else
        disp = "d-none";
    $('#controlBtns').html(`
                  <button class="btn btn-outline-info btn-block mb-2 all" id="all">All</button>
                  <div id="category">
                  </div>
                  <button class="btn btn-outline-success btn-block mt-2 ${disp}" id="newCtg">New category</button>
                  <button class="btn btn-outline-success btn-block mt-2 ${disp}" id="newItem">New item</button>
                  <button class="btn btn-outline-success btn-block mt-2 ${disp}" id="dltCtg">Delete category</button>
                  <button class="btn btn-outline-success btn-block mt-2 ${disp}" id="updCtg">Update category</button>`);
}

