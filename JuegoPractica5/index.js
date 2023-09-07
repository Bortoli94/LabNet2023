const inputNumber = document.getElementById("inputNumber");
const buttonInput = document.getElementById("inputButton");
const buttonRestart = document.getElementById("restartButton");
const showScore = document.getElementById("showScore");
const showHighScore = document.getElementById("highScore");
const help = document.getElementById("help");
const history = document.getElementById("history");
const main = document.getElementById("main");
const attemptsRemaining = document.getElementById("attemptsRemaining");

document.getElementById("form").addEventListener("submit", function(event) {
    event.preventDefault()})

let ramdonNumber = Math.floor(Math.random() * 20) + 1;
let score = 100;
let highScore = localStorage.getItem("highScore");
let classColor;
let intents = 5;

(highScore === null) ? highScore = 0 : undefined;
showScore.innerText = "Puntaje: " + score;
showHighScore.innerText = "Mejor puntaje: " + highScore;
attemptsRemaining.innerText = "Intentos restantes: " + intents;

buttonInput.addEventListener("click", () => {
    let inputInt = Number(inputNumber.value);
    if (inputInt < 1 || inputInt > 20) 
    {
        help.innerText = "Tiene que ser un numero entre 1 y 20";
        help.setAttribute("class", "warning")
    } 
    else
    {
        if (inputInt === ramdonNumber) 
                {
                    help.innerText = "Gano";
                    intents = 0;
                    buttonInput.disabled = true;
                    inputNumber.disabled = true;
                    main.style.backgroundColor = "#2d732d";
                    classColor = "win";
                    help.setAttribute("class", "winner");
                    if (score > highScore) 
                    {
                        highScore = score;
                        localStorage.setItem("highScore", score)
                        showHighScore.innerText = "Mejor puntaje: " + highScore;
                        help.innerText = "Gano Con Nuevo Mejor Puntaje";
                    }
                } 
        else 
        {
            help.innerText = (inputInt > ramdonNumber) ? "Es mas chico" : "Es mas grande"
            classColor= "fail"
            score = score - 20;
            intents = intents - 1;
        }
                const historyItem = document.createElement("li");
                historyItem.innerText = inputInt;
                historyItem.setAttribute("class", classColor);
                history.appendChild(historyItem);
    } 

    if (score === 0) 
    {
        help.innerText = "Perdiste, el numero era " + ramdonNumber;
        help.setAttribute("class", "losser");
        main.style.backgroundColor = "#ad3838";
        buttonInput.disabled = true;
        inputNumber.disabled = true;
    }
    showScore.innerText = "Puntaje: " + score;
    attemptsRemaining.innerText = "Intentos restantes: " + intents;
});

buttonRestart.addEventListener("click", () => {
  score = 100;
  showScore.innerText = "Puntaje: " + score;
  intents = 5;
  attemptsRemaining.innerText = "Intentos restantes: " + intents;
  inputNumber.value = "";
  history.innerText = "";
  help.innerText = "-";
  buttonInput.disabled = false;
  inputNumber.disabled = false;
  ramdonNumber = Math.floor(Math.random() * 20) + 1;
  main.style.backgroundColor = "#181b23";
  help.setAttribute("class", "");
});
