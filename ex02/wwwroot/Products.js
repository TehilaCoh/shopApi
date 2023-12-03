const cart = []
var count = 0;
var c = 0;
async function FilterProducts() {

    const minPrice = document.getElementById("minPrice").value
    const maxPrice = document.getElementById("maxPrice").value
    const nameSearch = document.getElementById("nameSearch").value
    let url = `api/Product?desc=${nameSearch}&minPrice=${minPrice}&maxPrice=${maxPrice}`
    let checkedCategories = [];
    const allCategoriesOptions = document.querySelectorAll(".opt");
    for (let i = 0; i < allCategoriesOptions.length; i++) {       
        if (allCategoriesOptions[i].checked)           
            checkedCategories.push(allCategoriesOptions[i].id)
    }
    for (let i = 0; i < checkedCategories.length; i++) {
        url += `&categoryIds=${checkedCategories[i]}`
    }
        const res = await fetch(url);
        const data = await res.json();

        document.getElementById("PoductList").replaceChildren([]);
        for (let i = 0; i < data.length; i++) {
            drawProduct(data[i])
        }  
}
async function showProducts() {
  
    const res = await fetch(`api/Product`);
    const data = await res.json();
    document.getElementById("counter").innerHTML = data.length;
    for (let i = 0; i < data.length; i++) {
        drawProduct(data[i])
    }
}
function drawProduct(product) {
        var temp = document.getElementById("temp-card");
        var clonProduct = temp.content.cloneNode(true);
        clonProduct.querySelector("h1").innerText = product.productName;
        clonProduct.querySelector(".price").innerText = product.price +"¤";
        clonProduct.querySelector("img").src = "images/" + product.image;
        clonProduct.querySelector(".description").innerText = product.description;
        clonProduct.querySelector("button").addEventListener('click', () => { addToCart(product) });
    document.getElementById("PoductList").appendChild(clonProduct);
}
async function getAllCategory() {   
    const res = await fetch("api/Category");
    const data = await res.json();
    for (let i = 0; i < data.length; i++) {
        console.log("hfff")
        showCategories(data[i])
    }   
}
const showCategories = async (category) => {

    let temp = document.getElementById("temp-category");
      
    let clonCategory = temp.content.cloneNode(true);
    clonCategory.querySelector("input").id = category.categoryId;
    clonCategory.querySelector("span.OptionName").innerText = category.categoryName;
        document.getElementById("categoryList").appendChild(clonCategory);
}

function addToCart(product) {
    count++;
    document.getElementById("ItemsCountText").innerHTML = count
    cart.push(product);
    sessionStorage.setItem("product", JSON.stringify(cart));
}   
getAllCategory();

   