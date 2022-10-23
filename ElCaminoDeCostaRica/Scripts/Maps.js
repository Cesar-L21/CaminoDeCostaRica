let map;
let service;
let infowindow;
let request;

const searchBtn = document.getElementById("searchBtn");
const locationBtn = document.getElementById("locationBtn");
const searchBox = document.getElementById("placeInput");
const latInput = document.getElementById("latitude");
const lngInput = document.getElementById("longitude");

searchBtn.addEventListener("click", function () { searchButtonClicked() }, false);

function searchButtonClicked() {
    let searchQuery = searchBox.value
    request = {
        query: searchQuery,
        fields: ["name", "geometry.location"],
    };
    searchPlace(request);
}

function searchPlace(requestInfo) {
    service = new google.maps.places.PlacesService(map);
    service.findPlaceFromQuery(requestInfo, (results, status) => {
        if (status === google.maps.places.PlacesServiceStatus.OK && results) {
            for (let i = 0; i < results.length; i++) {
                createMarker(results[i]);
            }
            map.setCenter(results[0].geometry.location);
        }
    });
}

function locationButtonClicked(infoWindow) {
    // Try HTML5 geolocation.
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(
            (position) => {
                const pos = {
                    lat: position.coords.latitude,
                    lng: position.coords.longitude,
                };
                latInput.value = position.coords.latitude;
                lngInput.value = position.coords.longitude;
                infoWindow.setPosition(pos);
                infoWindow.setContent("Ubicación actual");
                infoWindow.open(map);
                map.setCenter(pos);
            },
            () => {
                handleLocationError(true, infoWindow, map.getCenter());
            }
        );
    } else {
        // Browser doesn't support Geolocation
        handleLocationError(false, infoWindow, map.getCenter());
    }
}

function initMap() {
    infowindow = new google.maps.InfoWindow();
    map = new google.maps.Map(document.getElementById("map"), {
        center: { lat: 9.854328, lng: -83.610901 },
        zoom: 10,
        mapTypeId: 'satellite'
    });
    map.addListener("click", (event) => {
        displayLocationCoordinates(event.latLng, infowindow);
    });
    locationBtn.addEventListener("click", function () { locationButtonClicked(infowindow) }, false);
}

function displayLocationCoordinates(location, infowindow) {
    infowindow.setPosition(location);
    infowindow.setContent(
        "Latitud: " + location.lat() +
        "<br> Longitud: " + location.lng()
    );
    infowindow.open(map);
    latInput.value = location.lat();
    lngInput.value = location.lng();
}

function createMarker(place) {
    if (!place.geometry || !place.geometry.location) return;
    const marker = new google.maps.Marker({
        map,
        position: place.geometry.location,
    });
    latInput.value = place.geometry.location.lat();
    lngInput.value = place.geometry.location.lng();
    google.maps.event.addListener(marker, "click", () => {
        infowindow.setPosition(place.geometry.location);
        infowindow.setContent("Latitud: " + place.geometry.location.lat() +
            "<br> Longitud: " + place.geometry.location.lng());
        infowindow.open(map);
        latInput.value = place.geometry.location.lat();
        lngInput.value = place.geometry.location.lng();
    });
}

window.initMap = initMap;
