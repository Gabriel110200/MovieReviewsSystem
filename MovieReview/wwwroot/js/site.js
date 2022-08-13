document.addEventListener("DOMContentLoaded", function (e) {


    document.querySelector(".test").addEventListener("click", () => {
      
        sendData();


    });


    function sendData() {


        let form = document.getElementById("movie-form"); //$('#movie-form')

        let data = new FormData(form); //serialize 

        let genres = document.querySelectorAll(".genres"); //array de dom com inputs

        let activeGenres = [];
        let cont = 0;
        for (genre of genres) {

            if (genre.checked) {

                //activeGenres.push({ "GenreId": genre.value });
                data.append('Genres[' + cont + '].GenreId', genre.value);
                cont++;
            }

        }


        //data.append('Genres', JSON.stringify(activeGenres));  //genre.val()


        //console.log("CHECKBOX GENRE");

        //console.log(activeGenres);

        //console.log("");



        for (const pair of data.entries()) {
            console.log(`${pair[0]}, ${pair[1]}`);
        }



        //ajax post
        let url = window.location.href;


        
        fetch(url, {
            method: 'post',
            body: data
        }) 

    }



})