let carts_products = JSON.parse(sessionStorage.getItem("product"))
let sum_money = 0;

function drawProduct(product) {
    sum_money = 0

    for (let i = 0; i < carts_products.length; i++) {
        sum_money += carts_products[i].price;
    }
    var temp = document.getElementById("temp-row");
    var clonProduct = temp.content.cloneNode(true);

    document.getElementById("totalAmount").innerHTML = sum_money;
    document.getElementById("itemCount").innerHTML = carts_products.length;

   clonProduct.querySelector("img").src = "images/" + product.image;
    clonProduct.querySelector(".price").innerText = product.price + "�";
    clonProduct.querySelector(".descriptionColumn").innerText = product.description;
    clonProduct.querySelector(".totalColumn").addEventListener('click', () => { deleteProduct(product) });
    document.getElementById("myItem").appendChild(clonProduct);
}


function getProducts() {
    for (let i = 0; i < carts_products.length; i++) {
        drawProduct(carts_products[i])
       
    }      
}
function deleteProduct(product) {  
    carts_products = carts_products.filter(p => p != product);
    sessionStorage.setItem("carts_products", JSON.stringify(carts_products));//���� ������ �� ���� �����'
    document.getElementById("myItem").replaceChildren([])
    getProducts();
}

async function placeOrder() {
    var order = {
        orderDate: new Date(),
        orderSum: sum_money,
        userId: JSON.parse(sessionStorage.getItem("user")).userId,
        orderItems: carts_products


    };
    try {
        const response = await fetch("api/Order", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(order)
        })
        if (!response.ok)
            alert("faild... try again")
        else
            alert("your order invite sucssesfully")
    }   
    catch (err) {
        alert("err", err)

    }
   
}



//async function placeOrder() {
//    var order = {
//        orderDate: new Date(),
//        orderSum: count,
//        userId: JSON.parse(sessionStorage.getItem("user")).userId,
//        orderItems: products
//    };

//    try {
//        const response = await fetch("api/order", {
//            method: "POST",
//            headers: {
//                'Content-Type': 'application/json'
//            },
//            body: JSON.stringify(order)
//        })
//        if (!response.ok)
//            alert("faild... try again")
//        else
//            alert("your order invite sucssesfully")
//    }
//    catch (err) {
//        alert("err", err)

//    }
//    //let data = await res.json();

//}




