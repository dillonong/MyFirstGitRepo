'use strict'

/* This contents come from the Index.html */

var uri = 'api/products';

$(document).ready(function () {
    //Send an AJAX request ---- not sure if this is used anymore
    $.getJSON(uri).done(function (data) {
            //On success, 'data' will contain a list of products.
            $.each(data, function (key, item) {
                //Add a list item for the product
                $('<li>', { text: formatItem(item) }).appendTo($('#products'));
            });
        });
});

function formatItem(item) {
    return item.Name + ': $' + item.Price;
}

/* this gets called from the button click onclick event */
function find() {
    var id = $('#prodId').val();
    $.getJSON(uri + '/' + id)
        .done(function (data) {
            $('#product').text(formatItem(data));
        })
        .fail(function (jqXHR, textStatus, err) {
            $('#product').text('Error: ' + err);
        });
}

/* this gets called from the button click onclick event for find by category */
function findByCat() {
    var category = $('#prodCat').val();
    $.getJSON(uri + '?category=' + category)
        .done(function (data) {
            $.each(data, function (key, item) {
                //Add a list item for the product
                $('<li>', { text: formatItem(item) }).appendTo($('#foundProducts'));
            });
        })
        .fail(function (jqXHR, textStatus, err) {
            $('#product').text('Error' + err);
        });
}