function category(id, name)
{
    return `<button class="btn btn-outline-info btn-block ctg" id="${id}">${name}</button>`;
};

function card(id, name, description, price, image, disp)
{
    return `<div class="card col-2 mx-4 my-2" style="width:100%" id="${id}">
        <img class="card-img-top" src="${image}" alt="Card image" style="width:100%">
        <div class="card-body"> 
            <h4 class="card-title text-center">${name}</h4>
            <p class="card-text">${description}</p>
            <p class="card-text">${price}</p>
            <button id="${id}" class="btn btn-outline-success btn-block dltItem ${disp}">Delete</button>
            <button id="${id}" class="btn btn-outline-success btn-block updItem ${disp}">Update</button>
            <button id="${id}" class="btn btn-outline-success btn-block watchComments">Watch comments</button>
        </div>
    </div>`;
};

function cardAlone(id, name, description, price, image, categoryName)
{
    return `<div class="card col-3 mx-4 my-2" style="width:100%" id="${id}">
        <img class="card-img-top" src="${image}" alt="Card image" style="width:100%">
        <div class="card-body"> 
            <h4 class="card-title">${name}</h4>
            <p class="card-text">${description}</p>
            <p class="card-text">${price}</p>
            <p class="card-text">${categoryName}</p>
        </div>
    </div>`;
    
};

function createCategoryForm()
{
    return `<div class="col-12 text-center">
                <h5>Создать новую категорию</h5>
            </div>
            <div class="col-12">
            <form name="createForm">
                <div class="form-group">
                    <label for="name">Название</label>
                    <input class="form-control" name="name" id="name"/>
                </div>
            </form>
            <button class="btn btn-outline-success btn-block" id="createCategory">Добавить</button>
            </div>`;
}

function getCtgUpdateForm(id, name)
{
    return `<div class="col-12 text-center">
                <h5>Обновить категорию</h5>
            </div>
            <div class="col-12">
            <form name="createForm">
                <div class="form-group">
                    <label for="name">Название</label>
                    <input class="form-control" name="name" id="name" value="${name}"/>
                    <label class="d-none" for="id">Id</label>
                    <input class="form-control d-none" name="id" id="id" value="${id}"/>
                </div>
            </form>
            <button class="btn btn-outline-success btn-block" id="updateCategory">Обновить</button>
            </div>`;
}

function getItemUpdateForm(id, name, description, price, image)
{
    return `<div class="col-12 text-center">
                <h5>Обновить категорию</h5>
            </div>
            <div class="col-12">
            <form name="createForm">
                <div class="form-group">
                    <label for="name">Название</label>
                    <input class="form-control" name="name" id="name" value="${name}"/>
                    <label for="name">Описание</label>
                    <input class="form-control" name="description" id="description" value="${description}"/>
                    <label for="name">Цена</label>
                    <input class="form-control" name="price" id="price" value="${price}"/>
                    <label for="name">Картинка</label>
                    <input class="form-control" name="image" id="image" value="${image}"/>
                    <label for="selector">Категория</label>
                    <select id="selector" name="categoryId"></select>
                    <label class="d-none" for="id">Id</label>
                    <input class="form-control d-none" name="id" id="id" value="${id}"/>
                </div>
            </form>
            <button class="btn btn-outline-success btn-block" id="updateItem">Обновить</button>
            </div>`;
}

function createItemForm()
{
    return `<div class="col-12 text-center">
                <h5>Создать новый товар</h5>
            </div>
            <div class="col-12">
            <form name="createForm">
                <div class="form-group">
                    <label>Название</label>
                    <input class="form-control" name="name" />
                    <label>Цена</label>
                    <input class="form-control" name="price" />
                    <label>Описание</label>
                    <input class="form-control" name="description" />
                    <label>Ссылка на изображение</label>
                    <input class="form-control" name="image" />
                    <label for="selector">Категория</label>
                    <select class="form-control" id="selector" name="categoryId"></select>
                </div>
            </form>
            <button class="btn btn-outline-success btn-block" id="createItem">Добавить</button>
            </div>`;
}

function getCtgForDelete(id, name)
{
    return `<button class="btn btn-outline-info btn-block dltCtg" id="${id}">${name}</button>`;
};

function getCtgForUpdate(id, name)
{
    return `<button class="btn btn-outline-info btn-block updCtg" id="${id}">${name}</button>`;
};

function createLoginForm()
{
    return `<div class="col-12 text-center">
        <h5>Log in form</h5>
    </div>
    <div class="col-12">
    <form name="loginForm">
        <div class="form-group">
            <label for="email">Email</label>
            <input class="form-control" id="email" name="email">
            <label for="password">Password</label>
            <input class="form-control" id="password" name="password" type="password">
        </div>
        <button type="button" class="btn btn-outline-success btn-block" id="logmein">Log in</button>
    </form>
    </div>`;
};

function createRegForm()
{
    return `<div class="col-12 text-center">Sign up form</div>
    <div class="col-12">
    <form name="regForm">
        <div class="form-group">
            <label for="email">Email</label>
            <input class="form-control" id="email" name="email">
            <label for="name">Name</label>
            <input class="form-control" id="name" name="name">
            <label for="password">Password</label>
            <input class="form-control" id="password" name="password" type="password">
        </div>
        <button class="btn btn-outline-success btn-block" id="signmeup">Sign up</button>
    </form>
    </div>`;
}