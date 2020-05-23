function getAllItems(role)
{   
    if (role == "admin")
        disp = '';
    else
        disp = "d-none";
    $.ajax(
    {
        type: 'GET',
        url: '/api/item',
        dataType : "json", 
        success: function (data, textStatus)
        { 
            let items = "";
            data.forEach(function(item)
            {
                items = items + card(item.id, item.name, item.description, item.price, item.image, disp);
            });
            $('#content').html(items);
        } 
    });
};

function getItemsByCategory(id, role)
{
    if (role == "admin")
        disp = "";
    else
        disp = "d-none";
    $.ajax(
    {
        type: 'GET',
            url: `/api/item/category/${id}`,
        dataType : "json", 
        success: function (data, textStatus)
        { 
            let items = "";
            data.forEach(function(item)
            {
                items = items + card(item.id, item.name, item.description, item.price, item.image, disp);
            });
            $('#content').html(items);
        } 
    });
};

function createItem(name, description, price, image, categoryId)
{
    console.log(name, description, price + 1, image, categoryId);
    $.ajax(
    {
        type: 'POST',
            url: '/api/item',
        dataType : "json",
        contentType: "application/json; charset=utf-8",
        data: `{ 
            "Name": "${name}",
            "Description": "${description}",
            "Price": ${price},
            "Image": "${image}",
            "CategoryId": "${categoryId}" 
        }`,
        success: function (data, textStatus)
        {
            console.log(data);
            getAllItems("admin");
            getAllCategories();
        }
    });
};

function deleteItem(id)
{
    $.ajax(
    {
        type: "DELETE",
            url: `/api/item/${id}`,
        dataType: "json",
        success: function(data, textStatus)
        {
            getAllItems();
        }
    });
}

function createItemUpdateForm(id)
{
    $.ajax(
        {
            type: "GET",
            url: `/api/item/${id}`,
            dataType: "json",
            success: function(data, textStatus)
            {
                $("#content").html(getItemUpdateForm(data.id, data.name, data.description, data.price, data.image));
                getAllCtgsForSelect();
            }
        });
}

function updateItem(id, name, description, price, image, categoryId)
{
    $.ajax(
        {
            type: "PUT",
            url: `/api/item/`,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: `{ 
                "Id": "${id}",
                "Name": "${name}",
                "Description": "${description}",
                "Price": ${price},
                "Image": "${image}",
                "CategoryId": "${categoryId}" 
            }`,
            success: function(data, textStatus)
            {
                $("#content").html(getCtgUpdateForm(data.id, data.name));
                getAllItems("admin");
                getAllCategories();
            }
        });
}