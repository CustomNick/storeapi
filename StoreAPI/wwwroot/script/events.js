$('#controlBtns').delegate("#all", "click", function ()
{
    console.log("works");
    if (sessionStorage.getItem("token") != null) {
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
        var roles = getRolesById(parseJwt(sessionStorage.getItem("token")).sub);
        if (roles.indexOf("admin") in roles)
            getAllItems("admin");
        else
            getAllItems("user");
    }
    else{
      getAllItems("user");
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
    }
});

$("#controlBtns").delegate(".ctg", "click", function()
{
   if (sessionStorage.getItem("token") != null) {
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
      var roles = getRolesById(parseJwt(sessionStorage.getItem("token")).sub);
      if (roles.indexOf("admin") in roles)
         getItemsByCategory(this.id, "admin");
      else
         getItemsByCategory(this.id, "user");
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
      getItemsByCategory(this.id, "user");
  }
});

$("#controlBtns").delegate("#newCtg", "click", function ()
{
   $('#content').html(createCategoryForm()); 
});

$("#controlBtns").delegate("#newItem", "click", function ()
{
   $('#content').html(createItemForm());
   getAllCtgsForSelect();
});

$('#content').delegate("#createCategory", "click",function()
{
   createCategory(document.forms.createForm.name.value);
});

$('#content').delegate("#createItem", "click",function()
{
   console.log(document.forms.createForm.name.value, 
      document.forms.createForm.description.value, 
      document.forms.createForm.price.value, 
      document.forms.createForm.image.value, 
      document.forms.createForm.categoryId.selectedOptions[0].id);
   createItem(document.forms.createForm.name.value, 
      document.forms.createForm.description.value, 
      parseInt(document.forms.createForm.price.value, 10), 
      document.forms.createForm.image.value, 
      document.forms.createForm.categoryId.selectedOptions[0].id);
});

$('#content').delegate("#updateCategory", "click", function()
{
   console.log(document.forms.createForm.name.value, 
      document.forms.createForm.id.value);
   updateCategory(document.forms.createForm.id.value, 
      document.forms.createForm.name.value);
});

$('#content').delegate("#updateItem", "click", function()
{
   console.log(document.forms.createForm.id.value, 
      document.forms.createForm.name.value, 
      document.forms.createForm.description.value,
      parseInt(document.forms.createForm.price.value, 10),
      document.forms.createForm.image.value,
      document.forms.createForm.categoryId.selectedOptions[0].id);
   updateItem(document.forms.createForm.id.value, 
      document.forms.createForm.name.value, 
      document.forms.createForm.description.value,
      parseInt(document.forms.createForm.price.value, 10),
      document.forms.createForm.image.value,
      document.forms.createForm.categoryId.selectedOptions[0].id);
});

$("#content").delegate(".dltItem", "click", function()
{
   console.log(this.id);
   deleteItem(this.id);
})

$("#content").delegate(".updItem", "click", function()
{
   console.log(this.id);
   createItemUpdateForm(this.id);
})

$("#content").delegate(".watchComments", "click", function () {
    console.log(this.id);
    if (sessionStorage.getItem("token")) {
        id = parseJwt(sessionStorage.getItem("token")).sub;
        var roles = getRolesById(id);
        if (roles.indexOf("admin") in roles)
            commentsByItem(this.id, "admin");
        else
            commentsByItem(this.id, "user");
    }
    else
        commentsByItem(this.id, "user");
})

$("#controlBtns").delegate("#dltCtg", "click", function ()
{
   $('#content').html(getCtgsForDelete());
});

$("#controlBtns").delegate("#updCtg", "click", function ()
{
   $('#content').html(getCtgsForUpdate());
});

$("#content").delegate(".dltCtg", "click", function()
{
   console.log(this.id);
   deleteCtg(this.id);
});

$("#content").delegate(".updCtg", "click", function()
{
   console.log(this.id);
   createCategoryUpdateForm(this.id);
});

$("#header").delegate("#login", "click", function()
{
   $("#header").html(`
         <div class="col-10 bg-dark text-white">
            <a class="navbar-brand">Store for homework</a>
         </div>
         <div class="col-2 bg-dark text-white">
            <button style="cursor: pointer;" id="reg" class="btn btn-link">
               Sign up
            </button>
         </div>`);
   $('#content').html(createLoginForm());
});

$("#header").delegate("#reg", "click", function()
{
   $("#header").html(`
         <div class="col-10 bg-dark text-white">
            <a class="navbar-brand">Store for homework</a>
         </div>
         <div class="col-2 bg-dark text-white">
            <button style="cursor: pointer;" id="login" class="btn btn-link">
               Log in
            </button>
         </div>`);
   $('#content').html(createRegForm());
});

$("#content").delegate("#logmein", "click", function() {
   stopIt();
   LogIn(document.forms.loginForm.email.value,
      document.forms.loginForm.password.value);
});

$("#content").delegate("#signmeup", "click", function() {
   stopIt();
   Reg(document.forms.regForm.email.value,
      document.forms.regForm.name.value,
      document.forms.regForm.password.value);
});

$("#content").delegate("#sendComment", "click", function() {
    stopIt();
    if (sessionStorage.getItem("token") != null) {
        decoded = parseJwt(sessionStorage.getItem("token"));
        sendComment(document.forms.writeComment.text.value,
            decoded.sub,
            document.forms.writeComment.text.id);
    }
    else {
        sendComment(document.forms.writeComment.text.value,
            null,
            document.forms.writeComment.text.id);
    }
});

$("#content").delegate(".dltCmnt", "click", function () {
    stopIt();
    console.log(this.id, document.forms.writeComment.text.id);
    deleteComment(this.id, document.forms.writeComment.text.id);
});

$("#header").delegate("#logout", "click", function () {
    sessionStorage.removeItem("token");
    sessionStorage.removeItem("refreshToken");
    onStart();
});