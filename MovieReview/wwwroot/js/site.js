

$(document).ready(function () {




    $(".test").click(() => {
        let data = $('#movie-form').serialize();
        console.log(data);

        let genres = [];
        console.log($(".genres"));

        $(".genres").each((index) => {

            console.log($(this).val());
           // genres.push($(this).val());

        })
       // console.log(genres);

    })

   // console.log()


    /*
    $.ajax({
        url: window.location.href + '/movie/cerate',
        method: "POST"
        

    });*/


})