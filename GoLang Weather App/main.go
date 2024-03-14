<<<<<<< HEAD
package main

import (
	"encoding/json"
	"html/template"
	"net/http"
	"net/url"
	"time"
)

var tmpl *template.Template

func init() {
	tmpl = template.Must(template.ParseGlob("templates/*.html"))
}

func currHandler(w http.ResponseWriter, r *http.Request) {
	tmpl.ExecuteTemplate(w, "/weather.go", nil)
}
func homeHandler(w http.ResponseWriter, r *http.Request) {
	tmpl.ExecuteTemplate(w, "index.html", nil)
}

func historyHandler(w http.ResponseWriter, r *http.Request) {
	tmpl.ExecuteTemplate(w, "history.html", nil)
}

func searchHandler(w http.ResponseWriter, r *http.Request) {
	tmpl.ExecuteTemplate(w, "search.html", nil)
}
func registerHandler(w http.ResponseWriter, r *http.Request) {
	tmpl.ExecuteTemplate(w, "register.html", nil)
}
func forecastHandler(w http.ResponseWriter, r *http.Request) {
	tmpl.ExecuteTemplate(w, "forecast.html", nil)
}

/*testing onload*/
func indexWeatherHandler(w http.ResponseWriter, r *http.Request) {
	// Parse the city name from the request parameters

	// Calculate the date range for the last 7 days
	today := time.Now()
	//yesterday := today.AddDate(0, 0, -1)
	startDate := today.AddDate(0, 0, 1)
	endDate := today.AddDate(0, 0, 8)

	dateRange := []string{}
	for date := startDate; date.Before(endDate); date = date.AddDate(0, 0, 1) {
		dateRange = append(dateRange, date.Format("2006-01-02"))
	}
	dateRange = append(dateRange, endDate.Format("2006-01-02"))

	// Make separate API calls for each date in the date range
	data := []map[string]interface{}{}
	for _, date := range dateRange {
		apiURL := "http://api.weatherstack.com/forecast?access_key=027d422b684973798b66b13c626b937e&query=Dell_Rapids" + "&forecast_date=" + date
		resp, err := http.Get(apiURL)
		if err != nil {
			http.Error(w, err.Error(), http.StatusInternalServerError)
			return
		}
		defer resp.Body.Close()

		var responseData map[string]interface{}
		err = json.NewDecoder(resp.Body).Decode(&responseData)
		if err != nil {
			http.Error(w, err.Error(), http.StatusInternalServerError)
			return
		}

		data = append(data, responseData)
	}

	// Combine the weather data into a single JSON object
	combinedData := make(map[string]interface{})
	combinedData["city"] = "Dell_Rapids"
	combinedData["forecast"] = make(map[string]interface{})
	for i, date := range dateRange {
		forecastData := data[i]["forecast"].(map[string]interface{})
		if _, ok := forecastData[date]; ok {
			combinedData["forecast"].(map[string]interface{})[date] = forecastData[date]
		}
	}

	// Return the combined data as JSON
	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(combinedData)
}

/**/

/*testing forecast*/
func weatherForecastHandler(w http.ResponseWriter, r *http.Request) {
	// Parse the city name from the request parameters
	city := r.URL.Query().Get("city")
	if city == "" {
		http.Error(w, "City parameter is required", http.StatusBadRequest)
		return
	}

	// Calculate the date range for the last 7 days
	today := time.Now()
	//yesterday := today.AddDate(0, 0, -1)
	startDate := today.AddDate(0, 0, 1)
	endDate := today.AddDate(0, 0, 8)

	dateRange := []string{}
	for date := startDate; date.Before(endDate); date = date.AddDate(0, 0, 1) {
		dateRange = append(dateRange, date.Format("2006-01-02"))
	}
	dateRange = append(dateRange, endDate.Format("2006-01-02"))

	// Make separate API calls for each date in the date range
	data := []map[string]interface{}{}
	for _, date := range dateRange {
		apiURL := "http://api.weatherstack.com/forecast?access_key=027d422b684973798b66b13c626b937e&query=" + url.QueryEscape(city) + "&forecast_date=" + date
		resp, err := http.Get(apiURL)
		if err != nil {
			http.Error(w, err.Error(), http.StatusInternalServerError)
			return
		}
		defer resp.Body.Close()

		var responseData map[string]interface{}
		err = json.NewDecoder(resp.Body).Decode(&responseData)
		if err != nil {
			http.Error(w, err.Error(), http.StatusInternalServerError)
			return
		}

		data = append(data, responseData)
	}

	// Combine the weather data into a single JSON object
	combinedData := make(map[string]interface{})
	combinedData["city"] = city
	combinedData["forecast"] = make(map[string]interface{})
	for i, date := range dateRange {
		forecastData := data[i]["forecast"].(map[string]interface{})
		if _, ok := forecastData[date]; ok {
			combinedData["forecast"].(map[string]interface{})[date] = forecastData[date]
		}
	}

	// Return the combined data as JSON
	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(combinedData)
}

/**/
func weatherHandler(w http.ResponseWriter, r *http.Request) {
	city := r.URL.Query().Get("city")
	if city == "" {
		http.Error(w, "City parameter is required", http.StatusBadRequest)
		return
	}

	// Construct the API URL
	apiURL := "http://api.weatherstack.com/current?access_key=027d422b684973798b66b13c626b937e&query=" + url.QueryEscape(city)

	// Make the API request
	resp, err := http.Get(apiURL)
	if err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		return
	}
	defer resp.Body.Close()

	// Parse the JSON response
	var data map[string]interface{}
	err = json.NewDecoder(resp.Body).Decode(&data)
	if err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		return
	}

	// Return the response as JSON
	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(data)
}

func weatherHistoryHandler(w http.ResponseWriter, r *http.Request) {
	// Parse the city name from the request parameters
	city := r.URL.Query().Get("city")
	if city == "" {
		http.Error(w, "City parameter is required", http.StatusBadRequest)
		return
	}

	// Calculate the date range for the last 7 days
	today := time.Now()
	//yesterday := today.AddDate(0, 0, -1)
	startDate := today.AddDate(0, 0, -6)
	endDate := today.AddDate(0, 0, 0)

	dateRange := []string{}
	for date := startDate; date.Before(endDate); date = date.AddDate(0, 0, 1) {
		dateRange = append(dateRange, date.Format("2006-01-02"))
	}
	dateRange = append(dateRange, endDate.Format("2006-01-02"))

	// Make separate API calls for each date in the date range
	data := []map[string]interface{}{}
	for _, date := range dateRange {
		apiURL := "http://api.weatherstack.com/historical?access_key=027d422b684973798b66b13c626b937e&query=" + url.QueryEscape(city) + "&historical_date=" + date
		resp, err := http.Get(apiURL)
		if err != nil {
			http.Error(w, err.Error(), http.StatusInternalServerError)
			return
		}
		defer resp.Body.Close()

		var responseData map[string]interface{}
		err = json.NewDecoder(resp.Body).Decode(&responseData)
		if err != nil {
			http.Error(w, err.Error(), http.StatusInternalServerError)
			return
		}

		data = append(data, responseData)
	}

	// Combine the weather data into a single JSON object
	combinedData := make(map[string]interface{})
	combinedData["city"] = city
	combinedData["historical"] = make(map[string]interface{})
	for i, date := range dateRange {
		historicalData := data[i]["historical"].(map[string]interface{})
		if _, ok := historicalData[date]; ok {
			combinedData["historical"].(map[string]interface{})[date] = historicalData[date]
		}
	}

	// Return the combined data as JSON
	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(combinedData)
}

func main() {
	fs := http.FileServer(http.Dir("assets"))
	http.Handle("/assets/", http.StripPrefix("/assets", fs))
	http.HandleFunc("/", homeHandler)
	http.HandleFunc("/history", historyHandler)
	http.HandleFunc("/search", searchHandler)
	http.HandleFunc("/weather", weatherHandler)
	http.HandleFunc("/forecast", forecastHandler)
	http.HandleFunc("/weather-index", indexWeatherHandler)
	http.HandleFunc("/weather-history", weatherHistoryHandler)
	http.HandleFunc("/weather-forecast", weatherForecastHandler)

	http.ListenAndServe(":8001", nil)
}
=======
package main

import (
	"encoding/json"
	"html/template"
	"net/http"
	"net/url"
	"time"
)

var tmpl *template.Template

func init() {
	tmpl = template.Must(template.ParseGlob("templates/*.html"))
}

func currHandler(w http.ResponseWriter, r *http.Request) {
	tmpl.ExecuteTemplate(w, "/weather.go", nil)
}
func homeHandler(w http.ResponseWriter, r *http.Request) {
	tmpl.ExecuteTemplate(w, "index.html", nil)
}

func historyHandler(w http.ResponseWriter, r *http.Request) {
	tmpl.ExecuteTemplate(w, "history.html", nil)
}

func searchHandler(w http.ResponseWriter, r *http.Request) {
	tmpl.ExecuteTemplate(w, "search.html", nil)
}
func registerHandler(w http.ResponseWriter, r *http.Request) {
	tmpl.ExecuteTemplate(w, "register.html", nil)
}
func forecastHandler(w http.ResponseWriter, r *http.Request) {
	tmpl.ExecuteTemplate(w, "forecast.html", nil)
}

/*testing onload*/
func indexWeatherHandler(w http.ResponseWriter, r *http.Request) {
	// Parse the city name from the request parameters

	// Calculate the date range for the last 7 days
	today := time.Now()
	//yesterday := today.AddDate(0, 0, -1)
	startDate := today.AddDate(0, 0, 1)
	endDate := today.AddDate(0, 0, 8)

	dateRange := []string{}
	for date := startDate; date.Before(endDate); date = date.AddDate(0, 0, 1) {
		dateRange = append(dateRange, date.Format("2006-01-02"))
	}
	dateRange = append(dateRange, endDate.Format("2006-01-02"))

	// Make separate API calls for each date in the date range
	data := []map[string]interface{}{}
	for _, date := range dateRange {
		apiURL := "http://api.weatherstack.com/forecast?access_key=027d422b684973798b66b13c626b937e&query=Dell_Rapids" + "&forecast_date=" + date
		resp, err := http.Get(apiURL)
		if err != nil {
			http.Error(w, err.Error(), http.StatusInternalServerError)
			return
		}
		defer resp.Body.Close()

		var responseData map[string]interface{}
		err = json.NewDecoder(resp.Body).Decode(&responseData)
		if err != nil {
			http.Error(w, err.Error(), http.StatusInternalServerError)
			return
		}

		data = append(data, responseData)
	}

	// Combine the weather data into a single JSON object
	combinedData := make(map[string]interface{})
	combinedData["city"] = "Dell_Rapids"
	combinedData["forecast"] = make(map[string]interface{})
	for i, date := range dateRange {
		forecastData := data[i]["forecast"].(map[string]interface{})
		if _, ok := forecastData[date]; ok {
			combinedData["forecast"].(map[string]interface{})[date] = forecastData[date]
		}
	}

	// Return the combined data as JSON
	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(combinedData)
}

/**/

/*testing forecast*/
func weatherForecastHandler(w http.ResponseWriter, r *http.Request) {
	// Parse the city name from the request parameters
	city := r.URL.Query().Get("city")
	if city == "" {
		http.Error(w, "City parameter is required", http.StatusBadRequest)
		return
	}

	// Calculate the date range for the last 7 days
	today := time.Now()
	//yesterday := today.AddDate(0, 0, -1)
	startDate := today.AddDate(0, 0, 1)
	endDate := today.AddDate(0, 0, 8)

	dateRange := []string{}
	for date := startDate; date.Before(endDate); date = date.AddDate(0, 0, 1) {
		dateRange = append(dateRange, date.Format("2006-01-02"))
	}
	dateRange = append(dateRange, endDate.Format("2006-01-02"))

	// Make separate API calls for each date in the date range
	data := []map[string]interface{}{}
	for _, date := range dateRange {
		apiURL := "http://api.weatherstack.com/forecast?access_key=027d422b684973798b66b13c626b937e&query=" + url.QueryEscape(city) + "&forecast_date=" + date
		resp, err := http.Get(apiURL)
		if err != nil {
			http.Error(w, err.Error(), http.StatusInternalServerError)
			return
		}
		defer resp.Body.Close()

		var responseData map[string]interface{}
		err = json.NewDecoder(resp.Body).Decode(&responseData)
		if err != nil {
			http.Error(w, err.Error(), http.StatusInternalServerError)
			return
		}

		data = append(data, responseData)
	}

	// Combine the weather data into a single JSON object
	combinedData := make(map[string]interface{})
	combinedData["city"] = city
	combinedData["forecast"] = make(map[string]interface{})
	for i, date := range dateRange {
		forecastData := data[i]["forecast"].(map[string]interface{})
		if _, ok := forecastData[date]; ok {
			combinedData["forecast"].(map[string]interface{})[date] = forecastData[date]
		}
	}

	// Return the combined data as JSON
	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(combinedData)
}

/**/
func weatherHandler(w http.ResponseWriter, r *http.Request) {
	city := r.URL.Query().Get("city")
	if city == "" {
		http.Error(w, "City parameter is required", http.StatusBadRequest)
		return
	}

	// Construct the API URL
	apiURL := "http://api.weatherstack.com/current?access_key=027d422b684973798b66b13c626b937e&query=" + url.QueryEscape(city)

	// Make the API request
	resp, err := http.Get(apiURL)
	if err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		return
	}
	defer resp.Body.Close()

	// Parse the JSON response
	var data map[string]interface{}
	err = json.NewDecoder(resp.Body).Decode(&data)
	if err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		return
	}

	// Return the response as JSON
	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(data)
}

func weatherHistoryHandler(w http.ResponseWriter, r *http.Request) {
	// Parse the city name from the request parameters
	city := r.URL.Query().Get("city")
	if city == "" {
		http.Error(w, "City parameter is required", http.StatusBadRequest)
		return
	}

	// Calculate the date range for the last 7 days
	today := time.Now()
	//yesterday := today.AddDate(0, 0, -1)
	startDate := today.AddDate(0, 0, -6)
	endDate := today.AddDate(0, 0, 0)

	dateRange := []string{}
	for date := startDate; date.Before(endDate); date = date.AddDate(0, 0, 1) {
		dateRange = append(dateRange, date.Format("2006-01-02"))
	}
	dateRange = append(dateRange, endDate.Format("2006-01-02"))

	// Make separate API calls for each date in the date range
	data := []map[string]interface{}{}
	for _, date := range dateRange {
		apiURL := "http://api.weatherstack.com/historical?access_key=027d422b684973798b66b13c626b937e&query=" + url.QueryEscape(city) + "&historical_date=" + date
		resp, err := http.Get(apiURL)
		if err != nil {
			http.Error(w, err.Error(), http.StatusInternalServerError)
			return
		}
		defer resp.Body.Close()

		var responseData map[string]interface{}
		err = json.NewDecoder(resp.Body).Decode(&responseData)
		if err != nil {
			http.Error(w, err.Error(), http.StatusInternalServerError)
			return
		}

		data = append(data, responseData)
	}

	// Combine the weather data into a single JSON object
	combinedData := make(map[string]interface{})
	combinedData["city"] = city
	combinedData["historical"] = make(map[string]interface{})
	for i, date := range dateRange {
		historicalData := data[i]["historical"].(map[string]interface{})
		if _, ok := historicalData[date]; ok {
			combinedData["historical"].(map[string]interface{})[date] = historicalData[date]
		}
	}

	// Return the combined data as JSON
	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(combinedData)
}

func main() {
	fs := http.FileServer(http.Dir("assets"))
	http.Handle("/assets/", http.StripPrefix("/assets", fs))
	http.HandleFunc("/", homeHandler)
	http.HandleFunc("/history", historyHandler)
	http.HandleFunc("/search", searchHandler)
	http.HandleFunc("/weather", weatherHandler)
	http.HandleFunc("/forecast", forecastHandler)
	http.HandleFunc("/weather-index", indexWeatherHandler)
	http.HandleFunc("/weather-history", weatherHistoryHandler)
	http.HandleFunc("/weather-forecast", weatherForecastHandler)

	http.ListenAndServe(":8001", nil)
}
>>>>>>> refs/remotes/origin/main
