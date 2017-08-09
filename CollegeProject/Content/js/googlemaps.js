var myCenter = new google.maps.LatLng(31.969079, 34.770842);

function initialize() {
    var mapProp = {
        center: myCenter,
        zoom: 15,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);

    var marker = new google.maps.Marker({
        position: myCenter,
        animation: google.maps.Animation.BOUNCE
    });

    marker.setMap(map);


    google.maps.event.addListener(marker, 'click', function () {
        map.setZoom(18);
        map.setCenter(marker.getPosition());
    });

}

google.maps.event.addDomListener(window, 'load', initialize);