$(document).ready(function () {
    $('a.tree-toggler').click(function (e) {
        e.preventDefault();
        $(this).parent().children('ul.tree2').toggle(300);
        $(this).parent('li').toggleClass("open ");
    });

    $('a.mnul2').click(function (e) {
        e.preventDefault();
        $(this).parent().children('ul.tree').toggle(300);
        $(this).parent('li').toggleClass("open ");
    });
});


$('a.mnul2').click(function (e) {

    // prevent the default event behaviour    
    e.preventDefault();
    var link = $(this).data("category-id");
    var ftype = $(this).data("ftype");
    //alert(ftype);
    $.ajax({
        url: "/Flash/GetTopics/",
        type: "POST",
        data: { 'cid': link,'type':ftype },
        dataType: "html",
        success: function (data) {
            // perform your save call here
            $('#post_courses').html(data);
            /*if (data.status == "Success") {
                alert("Done");
            } else {
                alert("Error occurs on the Database level!");
            }*/
        },
        error: function () {
            alert("An error has occured!!!");
        }
    });
});

/*
$('.categories-list > li').click(function (e) {
    //console.log($(this).closest("a"));
    e.preventDefault();
    console.log($(this));
    if ($(this).hasClass("open"))
    {
        //console.log($(this));
        //close it then
        $(this).removeClass("open");
        //$(this).children('ul').attr("style", "display:none");
        $(this).children('ul').toggle() ;//.attr("style", "display:none");
    }
    else {
        //open or follow link
        $(this).addClass("open");
        $(this).parent("li").addClass("open");
        $(this).children('ul').toggle();
       // $(this).children('ul').attr("style", "display:block");
    }
    //var $chld = $(this).children('li.open');
    //console.log($chld);
    //$(this).parent().children('ul.open').toggle(200);
});
*/