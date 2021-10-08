// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
var empresas =
  {
    1: "Los loritos sac",
    2: "El rapido S.A",
    3: "Orion",
  }
var perfiles =
  {
    1: "Administrador",
    2: "Supervisor",
    3: "Contador",
    4: "Obrero",
    5: "Seguridad",
  }

// Write your JavaScript code.
function genera_tabla(data) {
  // Crea un elemento <table> y un elemento <tbody>
  var tbody = document.getElementsByTagName("tbody")[0];
  tbody.innerHTML = "";

  for (var i = 0; i < data.length; i++) {
    var usuario = data[i];
    var tf = document.createElement("tr");

    var td = document.createElement("td");
    var td2 = document.createElement("td");
    var td3 = document.createElement("td");
    var td4 = document.createElement("td");
    var td5 = document.createElement("td");

    td.appendChild(document.createTextNode(usuario["nombreUsu"]));
    td2.appendChild(document.createTextNode(usuario["correoUsu"]));
    td3.appendChild(document.createTextNode(perfiles[usuario["perfilUsu"]]));
    td4.appendChild(document.createTextNode(empresas[usuario["empresaUsu"]]));
    td5.appendChild(document.createTextNode(usuario["estadoUsu"]));

    tf.appendChild(td);
    tf.appendChild(td2);
    tf.appendChild(td3);
    tf.appendChild(td4);
    tf.appendChild(td5);

    tbody.appendChild(tf);
  }
}

var combo_perfil = document.getElementById("perfil");
combo_perfil.addEventListener("change", function () {
  load_users(combo_perfil.value, combo_empresa.value, true);

});
var combo_empresa = document.getElementById("empresa");
combo_empresa.addEventListener("change", function () {
  load_users(combo_perfil.value, combo_empresa.value, true);

});

// Ejemplo implementando el metodo POST:
async function getData(url = "", data = {}) {
  // Opciones por defecto estan marcadas con un *
  const response = await fetch(url + "?" + new URLSearchParams(data), {
    method: "GET", // *GET, POST, PUT, DELETE, etc.
    mode: "cors", // no-cors, *cors, same-origin
    cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
    credentials: "same-origin", // include, *same-origin, omit
    headers: {
      "Content-Type": "application/json",
      // 'Content-Type': 'application/x-www-form-urlencoded',
    },
    redirect: "follow", // manual, *follow, error
    referrerPolicy: "no-referrer", // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
  });
  return response.json(); // parses JSON response into native JavaScript objects
}
var mostrar_growl = function(mensaje){
  Swal.fire(mensaje)
}
var load_users = function (perfil, empresa, show_growl) {
  var param = {};
  var mensaje ="Proceso completado para ";
  if (perfil > 0) {
    param["perfil"] = perfil;
    mensaje+="el perfil "+ perfiles[perfil];
    if(empresa>0){
      mensaje+=" y "
    }
  }
  if (empresa > 0) {
    param["empresa"] = empresa;
    mensaje+="la empresa "+ empresas[empresa];
  }
  if(perfil<=0 && empresa<=0){
    show_growl=false;
  }
  
  return getData("https://localhost:5001/api/Users", param).then((data) => {
    genera_tabla(data); // JSON data parsed by `data.json()` call
    if (show_growl){
      mostrar_growl(mensaje)
    }
  });
};
window.onload = function() {
  load_users(0,0, false);
};