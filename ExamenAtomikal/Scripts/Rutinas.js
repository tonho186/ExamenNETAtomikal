function cargarInicio() {
    window.onload = function () {
        var btnRegistrar = document.getElementById("btnRegistrar");
        if (btnRegistrar != null) {
            btnRegistrar.onclick = function () {
                return(validarRegistro());
            }
        }
    }
}

function validarCampo(idControl, campo) {
    var control = document.getElementById(idControl);
    if (control != null) {
        if (control.value.trim() == "") {
            alert("Ingresa " + campo);
            control.focus();
            return false;
        }
    } else return false;
    return true;
}

function validarRegistro() {
    if (validarCampo("txtCodigo", "Código") == false) return false;
    if (validarCampo("Nombre", "Nombre") == false) return false;
    if (validarCampo("Correo", "Correo") == false) return false;
    if (validarCampo("txtPassword", "Password") == false) return false;
    return true;
}