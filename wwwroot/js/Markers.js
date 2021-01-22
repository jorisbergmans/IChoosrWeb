let map;

function initMap() {
    map = new google.maps.Map(document.getElementById("map"), {
        zoom: 2,
        center: new google.maps.LatLng(2.8, -187.3),
        mapTypeId: "terrain",
    });
    const script = document.createElement("script");
    script.src = "JavaScripts/Markers.js";
    document.getElementsByTagName("head")[0].appendChild(script);
}

// Loop through the results array and place a marker for each
// set of coordinates.
const eqfeed_callback = function (results) {
    results.forEach(function (camera) {
        const latLng = new google.maps.LatLng(camera.Latitude, camera.Longitude);
        new google.maps.Marker({
            position: latLng,
            map: map,
        });
    })
};