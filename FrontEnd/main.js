const baseUrl = "https://localhost:44386/WeatherForecast15Days?location=";
const currentDate = new Date()

let city;
document.getElementById('city_input').addEventListener('keypress', (e) => {
    if (e.key === 'Enter') {
        city = e.target.value;
        console.log("Submitted:", city);


        fetch(baseUrl + city)
            .then(response=>{
                if(!response.ok){
                    throw new Error("Failed to fetch city data.");
                }
                console.log("Fetched!");
                return response.json();
            })
            .then(data=>{
                console.log(data);

                document.getElementById("weather_div").style.visibility = "visible";

                document.getElementById("city").innerHTML = data.city;


                let date = currentDate.toString().split(' ');
                let time = date[4].split(':');
                document.getElementById("date").innerHTML = date[0] + " "
                + date[1] + " " + date[2] + " " + date[3] + " " + time[0] + ":" + time[1];

                document.getElementById("temperature").innerHTML = data.currentConditions.temp + "°";

                document.getElementById("condition").innerHTML = data.currentConditions.conditions;

                changeIcon(data.currentConditions.icon, "current_weather_image");

                document.getElementById("temperature_high").innerHTML = data.days[0].tempmax + "°";

                document.getElementById("temperature_low").innerHTML = data.days[0].tempmin + "°";

                document.getElementById("wind").innerHTML = data.days[0].windspeed + "km/h";

                if(data.currentConditions.precipprob === null){
                    document.getElementById("rain_chance").innerHTML = "0%";
                }
                else{
                    document.getElementById("rain_chance").innerHTML = data.currentConditions.precipprob + "%";
                }

                let sunrise = data.currentConditions.sunrise.split(":");
                document.getElementById("sunrise").innerHTML = sunrise[0] + ":" + sunrise[1];

                let sunset = data.currentConditions.sunset.split(":");
                document.getElementById("sunset").innerHTML = sunset[0] + ":" + sunset[1];

                createCard(data);

            })
        .catch(err=>{
            console.error("Error:", err);
        })

    }
});




function createCard(data){

    const container = document.getElementById("next_week_cards_div");
    container.innerHTML = ``;

    for(let i = 1; i < data.days.length; i++) {
        const card = document.createElement('div');

        card.id = `card_${i}_div`;
        card.className = 'card';

        const day_i = `card_${i}`
        const card_image_i = `card_image_${i}`
        const min_temp_i = `min_temp_${i}`
        const max_temp_i = `max_temp_${i}`
        card.innerHTML = `
        <p id=${day_i}>DOW</p>
        <p id=${card_image_i} class="material-symbols-outlined card_image">sunny</p>
        <div class="dow_data">
            <p id = ${min_temp_i} class = "min_temp">6°</p>
            <p>|</p>
            <p id = ${max_temp_i} class = "max_temp">20°</p>
        </div>`


        container.appendChild(card);

        let nextDay = new Date();
        nextDay.setDate(currentDate.getDate() + i);
        let dow = nextDay.toString().split(' ');
        console.log(dow[0]);
        document.getElementById(day_i).textContent = dow[0];

        document.getElementById(min_temp_i).textContent = data.days[i].tempmin + "°";
        document.getElementById(max_temp_i).textContent = data.days[i].tempmax + "°";

        // document.getElementById(card_image_i).style.margin = "0";
        // document.getElementById(card_image_i).style.padding = "0";
        // document.getElementById(card_image_i).style.fontSize = "70px";

        changeIcon(data.days[i].icon ,card_image_i);

    }

}

function changeIcon(APIicon, icon_id){
    if(APIicon === 'partly-cloudy-day'){
        document.getElementById(icon_id).textContent = "partly_cloudy_day";
    }
    else if(APIicon === 'snow'){
        document.getElementById(icon_id).textContent = "snowing";
    }
    else if(APIicon === 'rain'){
        document.getElementById(icon_id).textContent = "rainy";
    }
    else if(APIicon === 'fog'){
        document.getElementById(icon_id).textContent = "foggy";
    }
    else if(APIicon === 'wind'){
        document.getElementById(icon_id).textContent = "air";
    }
    else if(APIicon === 'cloudy'){
        document.getElementById(icon_id).textContent = "cloud";
    }
    else if(APIicon === 'partly-cloudy-night'){
        document.getElementById(icon_id).textContent = "partly_cloudy_night";
    }
    else if(APIicon === 'clear-day'){
        document.getElementById(icon_id).textContent = "sunny";
    }
    else if(APIicon === 'clear-night'){
        document.getElementById(icon_id).textContent = "bedtime";
    }
    else{
        document.getElementById(icon_id).textContent = "error";
    }
}







