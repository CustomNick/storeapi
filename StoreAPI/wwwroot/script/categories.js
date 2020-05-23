function getAllCategories()
{
    $.ajax(
    {
        type: 'GET',
            url: '/api/category',
        dataType : "json", 
        success: function (data, textStatus)
        { 
            let cat = "";
            data.forEach(function(item)
            {
                cat = cat + category(item.id, item.name);
            });
            $('#category').html(cat);
        } 
    });
}; 

function getAllCtgsForSelect()
{
    $.ajax(
    {
        type: "GET",
            url: "/api/category",
        dataType: "json",
        success: function(data, textStatus)
        {
            let cats = "";
            data.forEach(function(item)
            {
                cats = cats + `<option id="${item.id}">${item.name}</option>`;
            });
            $('#selector').html(cats);
        }
    }
    )
}

function createCategory(name)
{
    $.ajax(
    {
        type: 'POST',
            url: '/api/category',
        dataType : "json",
        contentType: "application/json; charset=utf-8",
        data: `{ "Name": "${name}" }`,
        success: function (data, textStatus)
        {
            getAllItems("admin");
            getAllCategories();
        }
    });
};

function getCtgsForDelete()
{
    $.ajax(
        {
            type: 'GET',
            url: '/api/category',
            dataType : "json",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus)
            {
                let ctgs = "";
                data.forEach(function(ctg)
                {
                    ctgs = ctgs + getCtgForDelete(ctg.id, ctg.name);
                })
                $("#content").html(ctgs);
            }
        });
}

function getCtgsForUpdate()
{
    $.ajax(
        {
            type: 'GET',
            url: '/api/category',
            dataType : "json",
            contentType: "application/json; charset=utf-8",
            success: function (data, textStatus)
            {
                let ctgs = "";
                data.forEach(function(ctg)
                {
                    ctgs = ctgs + getCtgForUpdate(ctg.id, ctg.name);
                })
                $("#content").html(ctgs);
            }
        });
}

function deleteCtg(id)
{
    $.ajax(
    {
        type: "DELETE",
            url: `/api/category/${id}`,
        dataType: "json",
        success: function(data, textStatus)
        {
            getAllCategories();
            getAllItems("admin");
        }
    });
}

function createCategoryUpdateForm(id)
{
    $.ajax(
        {
            type: "GET",
            url: `/api/category/${id}`,
            dataType: "json",
            success: function(data, textStatus)
            {
                $("#content").html(getCtgUpdateForm(data.id, data.name));
            }
        });
}

function updateCategory(id, name)
{
    $.ajax(
        {
            type: "PUT",
            url: `/api/category/`,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: `{ 
                "Name": "${name}",
                "Id": "${id}"
            }`,
            success: function(data, textStatus)
            {
                $("#content").html(getCtgUpdateForm(data.id, data.name));
                getAllItems("admin");
                getAllCategories();
            }
        });
}