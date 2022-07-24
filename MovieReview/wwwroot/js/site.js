

document.addEventListener("DOMContentLoaded",function (e) {


    let teste =  document.querySelector(".test")
   
    teste.addEventListener('click', () => {


        let form = document.getElementById("movie-form");
    
        let data = new FormData(form); //serialize 

        let genres = document.querySelectorAll(".genres");

        data.append('genreId', genre.value);


        /*
        for (genre of genres)
        {
            data.append('genreId', genre.value);
        }*/
       
     
        
        console.log(data);


        for (const pair of data.entries())
        {
            console.log(`${pair[0]}, ${pair[1]}`);
        }



          /*
        console.log(data.get('Title'));
        console.log()


      

        let data = document.querySelector('#movie-form').serializeArray();



        let genres = [];

        let allGenres = document.querySelectorAll(".genres");

        console.log(allGenres); */


        /*

        $(".genres").each((index,element) => {

            genres.push($(element).val());

        }) 

        data.push(genres);

        console.log(data);*/

        

    })

   // console.log()


    /*
    $.ajax({
        url: window.location.href + '/movie/cerate',
        method: "POST"
        

    });*/


})