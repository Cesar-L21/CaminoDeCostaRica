const { type } = require("jquery");

function enableDisability() {
    // Get disability select object
    var disabilityObject = document.getElementById("disability");
    var disabilityValue = disabilityObject.value;
    var disabilityTextBox = document.getElementById("disabilityBox");
    if (disabilityValue == "Sí") {
        disabilityTextBox.disabled = false;
    } else {
        disabilityTextBox.value = "";
        disabilityTextBox.disabled = true;
    }
}

function enableHipertension() {
    var cbHipertension = document.getElementById("hipertension");
    var hiperValue = cbHipertension.checked;
    var hiperBox = document.getElementById("hiperBox");
    if (hiperValue) {
        hiperBox.disabled = false;
    } else {
        hiperBox.value = "";
        hiperBox.disabled = true;
    }
}

function enableDiabetes() {
    var cbDiabetes = document.getElementById("diabetes");
    var diabetesValue = cbDiabetes.checked;
    var diabetesBox = document.getElementById("diabetesBox");
    if (diabetesValue) {
        diabetesBox.disabled = false;
    } else {
        diabetesBox.value = "";
        diabetesBox.disabled = true;
    }
}

function enableCancer() {
    var cbCancer = document.getElementById("cancer");
    var cancerValue = cbCancer.checked;
    var cancerBox = document.getElementById("cancerBox");
    if (cancerValue) {
        cancerBox.disabled = false;
    } else {
        cancerBox.value = "";
        cancerBox.disabled = true;
    }
}

function otherEnable() {
    var cbOther = document.getElementById("otro");
    var otherValue = cbOther.checked;
    var especBox = document.getElementById("otroEspBox");
    var otherTreatment = document.getElementById("otroTreatBox");
    if (otherValue) {
        especBox.disabled = false;
        otherTreatment.disabled = false;
    } else {
        especBox.value = "";
        especBox.disabled = true;
        otherTreatment.value = "";
        otherTreatment.disabled = true;
    }
}

function createDiseaseOption(id) {
    var container = document.getElementById("diseases");
    var diseaseLabel = document.createElement("p");
    diseaseLabel.innerText = "Enfermedad";
    var diseaseBox = document.createElement("input");
    diseaseBox.type = "text";
    diseaseBox.name = "numero" + id;
    var treatmentLabel = document.createElement("p");
    treatmentLabel.innerText = "Tratamiento";
    var treatmenBox = document.createElement("input");
    treatmenBox.name = "numero" + (id + 1);
    treatmenBox.type = "text";

    container.appendChild(diseaseLabel);
    container.appendChild(diseaseBox);
    container.appendChild(treatmentLabel);
    container.appendChild(treatmenBox);
}

function addDisability() {
    var disabilitySelector = document.getElementById("disabilitySelector");
    var disabilityValue = disabilitySelector.value;
    var disabilityBox = document.getElementById("disabilityBox");
    if (disabilityValue == "Sí") {
        disabilityBox.type = "text";
    } else {
        disabilityBox.type = "hidden";
        disabilityBox.innerText = "";
    }
}