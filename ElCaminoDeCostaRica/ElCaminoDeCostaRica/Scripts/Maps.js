let map;
let service;
let infowindow;
let request;

const searchBtn = document.getElementById("searchBtn");
const searchBox = document.getElementById("placeInput");
<<<<<<< HEAD
=======
const latInput = document.getElementById("latitude");
const lngInput = document.getElementById("longitude");
>>>>>>> Cesar

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

function initMap() {
    infowindow = new google.maps.InfoWindow();
    map = new google.maps.Map(document.getElementById("map"), {
        center: { lat: 9.854328, lng: -83.610901 },
<<<<<<< HEAD
        zoom: 12,
        mapTypeId: 'satellite'
    });

=======
        zoom: 8,
        mapTypeId: 'satellite'
    });
>>>>>>> Cesar
    map.addListener("click", (event) => {
        displayLocationCoordinates(event.latLng, infowindow);
    });
}


function displayLocationCoordinates(location, infowindow) {
    infowindow.setPosition(location);
    infowindow.setContent(
        "Latitud: " + location.lat() +
        "<br> Longitud: " + location.lng()
    );
    infowindow.open(map);
<<<<<<< HEAD
=======
    latInput.value = location.lat();
    lngInput.value = location.lng();
>>>>>>> Cesar
}

function createMarker(place) {
    if (!place.geometry || !place.geometry.location) return;
    const marker = new google.maps.Marker({
        map,
        position: place.geometry.location,
    });
<<<<<<< HEAD

=======
    latInput.value = place.geometry.location.lat();
    lngInput.value = place.geometry.location.lng();
>>>>>>> Cesar
    google.maps.event.addListener(marker, "click", () => {
        infowindow.setPosition(place.geometry.location);
        infowindow.setContent("Latitud: " + place.geometry.location.lat() +
            "<br> Longitud: " + place.geometry.location.lng());
        infowindow.open(map);
<<<<<<< HEAD
=======
        latInput.value = place.geometry.location.lat();
        lngInput.value = place.geometry.location.lng();
>>>>>>> Cesar
    });
}

window.initMap = initMap;
