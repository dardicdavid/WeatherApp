const baseUrl = "https://localhost:44386/WeatherForecastToday?location=";
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
            })
        .catch(err=>{
            console.error("Error:", err);
        })
    }
});



