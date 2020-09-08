if (document.readyState == "loading") {
    document.addEventListener("DOMContentLoaded", ready)
}
else {
    ready()
}

var products = []
var toSend=[]

function verifiyOk(array) {
    var ok = true;
    if (array != null) {
        for (var i = 0; i < array.length; i++) {
            if (localStorage.getItem(array[i].titlu) == 0) {
                ok = false;
                break;
            }
        }
    }
    return ok;
}

function ready() {
    set();
}

function updateTotal() {
    var prices = document.getElementsByClassName("cart-item-price");
    var titles = document.getElementsByClassName("cart-item-title");
    var aux = 0;
    for (var i = 0; i < prices.length; i++) {
      
       aux+=( parseInt(localStorage.getItem(titles[i].innerText)) * parseInt(prices[i].innerText))
    }
    document.getElementById("totalPrice").innerText = aux+" $";
}
function set() {
    products = JSON.parse(localStorage.getItem("products"));
   

    if (verifiyOk(products) == true) {
        var productsAux = products.filter((value, index, self) => self.map(x => x.titlu).indexOf(value.titlu) == index)


        for (var i = 0; i < productsAux.length; i++) {

            if (productsAux[i] != "") {
              
            var div = document.createElement("div");

                var productsBought = `
              <img src="" class="img-fluid" style="width:80px; height:80px; margin-left:13px; margin-top:10px;"/>
            <div class="container" id="prDiv">
            <label type="text" ><b>PRODUCT:</b> </label>
            <span class="cart-item-title" id="title" name="title"><b>${productsAux[i].titlu}</b></span>
            <br>
            <label type="text" ><b>PRICE: </b></label>
            <span class="cart-item-price" id="price" name="price"><b>${productsAux[i].pret}</b></span>
            <br>
            <label type="text"><b>QUANTITY:</b> </label>
            <span class="cart-item-quantity" id="quantity" name="quantity"><b>${localStorage.getItem(productsAux[i].titlu)}</b></span>
            <button class="btn btn-danger" >REMOVE</button>
            </div>
            <br>
            <br>
         
            `
              
                div.innerHTML = productsBought;
             
            //     document.body.appendChild(div);
                document.getElementById('mainDiv').appendChild(div)
               
            }
        }
        var totalSpan = `<span style="margin-left:13px"> <b>TOTAL: <span class="total" id="totalPrice"></span></b> </span> <br> <br> <br> <br>`
        var span = document.createElement("span");
        span.innerHTML = totalSpan;
        document.getElementById('mainDiv').appendChild(span);


        var removeButtons = document.getElementsByClassName("btn btn-danger");
        for (var i = 0; i < removeButtons.length; i++) {
            removeButtons[i].addEventListener("click", removeElement);
        }
        var orderB = document.getElementById("orderB");
        orderB.addEventListener("click", function () {
          
            var inputName = document.getElementById("inputName").value;
            var inputAddress = document.getElementById("inputAddress").value;
            var inputMail = document.getElementById("inputMail").value;
            var auxArray = [];
            for (var i = 0; i < productsAux.length; i++) {
                if (productsAux[i]!="") {
                auxArray[i-1] = { "productName": productsAux[i].titlu, "productPrice": productsAux[i].pret, "quantity": localStorage.getItem(productsAux[i].titlu) };
                }
            }


            document.getElementById("inputProducts").value = JSON.stringify(auxArray);

            var shoppingCart = {
                productList: auxArray,
                clientName: inputName,
                clientAddress: inputAddress,
                clientMail: inputMail
            };
            
            $.ajax({
                type: "POST",
                data: JSON.stringify(shoppingCart),
                url: "senditems/save",
                contentType: "application/json;charset=utf-8",
                
            })
            
        })
        updateTotal()
    }

}

function numOfOccurence(arr,val) {
    var k = 0;
    for (var i = 0; i < arr.length; i++) {
        if (arr[i] === val) {
            k++;
        }
    }
    return k;
}

function removeElement(event) {
   
    var buttonClicked = event.target;
    buttonClicked.parentElement.parentElement.remove();
    updateTotal();
    var nameToRemove = buttonClicked.previousSibling.previousSibling.previousSibling.previousSibling.previousSibling.previousSibling.previousSibling.previousSibling.previousSibling.previousSibling.previousSibling.previousSibling.previousSibling.previousSibling.innerText;
    var auxProd = JSON.parse(localStorage.getItem("products"));
    var titles = [];

    for (var i = 0; i < auxProd.length; i++) {
        titles[i] = auxProd[i].titlu;
    }
    
   
    var index = 0;
    for (var i = 0; i < auxProd.length; i++) {
        if (auxProd[i].titlu === nameToRemove) {
            index = auxProd.indexOf(auxProd[i]);
            if (index > -1) {
                auxProd.splice(index, numOfOccurence(titles, nameToRemove));
              
            }
        }
    }
    var auxQuant = parseInt(localStorage.getItem(nameToRemove));
    console.log(auxQuant);
    localStorage.setItem("products", JSON.stringify(auxProd));
    updateQuantity(auxQuant);
}

function updateQuantity(num) {
    var numProducts = localStorage.getItem("totalProducts");
    if (numProducts) {
        if (numProducts - num >= 0) {
            document.getElementById("quant").innerText = numProducts - num;
            localStorage.setItem("totalProducts", numProducts - num);
        }
        else {
            document.getElementById("quant").innerText =0;
            localStorage.setItem("totalProducts", 0);
        }
    }
}

function setTheCart() {
    var numProducts = localStorage.getItem("totalProducts");
    if (numProducts) {
        document.getElementById("quant").innerText = numProducts

    }

}

var images = document.getElementsByClassName("img-fluid");
if (images != null) {
    var aux = JSON.parse(localStorage.getItem("products"));
    var productsAux = aux.filter((value, index, self) => self.map(x => x.titlu).indexOf(value.titlu) == index)
    var titles = []
}
for (var i = 0; i < productsAux.length; i++) {
    if (productsAux[i] != "") {
        titles[i] = productsAux[i].titlu;
        console.log(titles[i]);
    }
}

for (var i = 0; i < titles.length; i++) {
    if (titles[i] === "Tommy Hilfiger T-Shirt") {
        images[i - 1].src = "/lib/tommyH.jpg";
    }
    if (titles[i] === "Tommy Hilfiger T-Shirt 2") {
        images[i - 1].src = "/lib/h6.jpg";
    }
    if (titles[i] === "Tommy Hilfiger T-Shirt 3") {
        images[i - 1].src = "/lib/h3.jpg";
    }
    if (titles[i] === "Nike Sneakers Orange") {
        images[i - 1].src = "/lib/n4.jpg";
    }
    if (titles[i] === "Nike Sneakers Gray") {
        images[i - 1].src = "/lib/n5.jpg";
    }
    if (titles[i] === "Nike Sneakers Black") {
        images[i - 1].src = "/lib/n3.jpg";
    }
    if (titles[i] === "Shades Black") {
        images[i - 1].src = "/lib/s1.jpg";
    }
    if (titles[i] === "Shades Blue") {
        images[i - 1].src = "/lib/s2.jpg";
    }
    if (titles[i] === "Shades Red") {
        images[i - 1].src = "/lib/s3.jpg";
    }
    if (titles[i] === "Shades Holo") {
        images[i - 1].src = "/lib/s4.jpg";
    }
}

document.getElementById("clientName").innerText = "FULL NAME";
document.getElementById("clientAddress").innerText = "FULL ADDRESS";
document.getElementById("clientMail").innerText = "E-MAIL";


setTheCart()

