const canvas = document.getElementById('spiromania');
const ctx = canvas.getContext('2d');
const drawButton = document.getElementById('drawButton');
const drawOne = document.getElementById('drawOne');
const clearButton = document.getElementById('clearButton');

const canvasWidth = 500;
const canvasHeight = 500;
const centerX = canvasWidth / 2;
const centerY = canvasHeight / 2;

const minA = 10;
const maxA = 30;
const minD = 40;

window.addEventListener('load', (event) => {
  drawButton.addEventListener('click', (event) => {
    let numSpins = Math.floor(Math.random(25)) + 20;
    
    // First clear the canvas
    clearCanvas();

    for(let i = 0; i < numSpins; i++) {
      doDrawing();
    }
  });

  drawOne.addEventListener('click', (event) => {
    doDrawing();
  });

  clearButton.addEventListener('click', clearCanvas)
});

function doDrawing() {
  let aVal = Math.floor(Math.random() * (maxA - minA) + minA);
  aVal *= 10;
  let dVal = minD + (Math.random(7) * 5)
  let numSpins = Math.random(25) + 1;
  spinWheels(aVal, 70, dVal);
}

function clearCanvas() {
  ctx.beginPath();
  ctx.clearRect(0, 0, canvasWidth, canvasHeight);
  ctx.fill();
}

function highestCommonFactor(num1, num2) {
  let hcf = 0;
  let i = 0;
  let j = 0;

  if (num1 < num2) {
    hcf = num1;
    i = num2;
  } else {
    hcf = num2;
    i = num1;
  }

  do {
    j = i % hcf;
    if (j != 0) {
      i = hcf;
      hcf = j;
    }
  } while(j != 0);

  return hcf;
}

function spinWheels(a, b, d) {
  let rab = a - b;
  let alpha = 0;
  let aOverB = a / b;
  const aDif = Math.PI / 100;
  const lines = 200 * (b / highestCommonFactor(a, b));

  ctx.strokeStyle = getColor();
  ctx.lineWidth = 1;

  ctx.beginPath();
  ctx.moveTo((Math.round(rab + d) + centerX), centerY);

  for(i=1; i <= lines; i++) {
    alpha = alpha + aDif;
    beta = alpha * aOverB;
    xPt = rab * Math.cos(alpha) + d * Math.cos(beta);
    yPt = rab * Math.sin(alpha) - d * Math.sin(beta);
    ctx.lineTo((Math.round(xPt) + centerX), Math.round(yPt) + centerY);
  }

  ctx.closePath();
  ctx.stroke();

}

function getColor() {
  let red = Math.random() * (255);
  let green = Math.random() * (255);
  let blue = Math.random() * (255);
  return 'rgb(' + red.toString() + ',' + green.toString() + ',' + blue.toString() + ')';
}
