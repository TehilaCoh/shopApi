
const login = async () => {
    try {
        var email = document.getElementById("userNameLogin").value
        var password = document.getElementById("passwordLogin").value
        var user = { email, password }
        const res = await fetch('api/User/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)

        });

        if (!res.ok) {
            throw new Error("the password or the userName is worng!!!")
        }
        else {
            var data = await res.json()
            sessionStorage.setItem("user", JSON.stringify(data))

            window.location.href = "./Products.html"

        }
    }
    catch (er) {
        alert(er.message)
    }

}
const register = async () => {
    var email = document.getElementById("userNameRegister").value;
   
    var em = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;


    if (!em.test(email)) {
        alert("your adress is not valid!!!!!!!!!")
        return;
    }
    var password = document.getElementById("passwordRegister").value;
    var firstName = document.getElementById("firstName").value;
    var lastName = document.getElementById("lastName").value;
    var user = { email, password, firstName, lastName }
    try {
        const res = await fetch('api/User', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)

        });
        alert("user created sucssesfuly. please login now");
    }
    catch (er) {
        alert(er.message)
    }
}

const update = async () =>
{
    const userFromStorage = sessionStorage.getItem("user")
    const user = JSON.parse(userFromStorage)
    console.log(user);
    const firstName = document.getElementById("firstName").value ? document.getElementById("firstName").value: user.firstName
    const lastName = document.getElementById("lastName").value ? document.getElementById("lastName").value: user.lastName
    const email = document.getElementById("userName").value ? document.getElementById("userName").value: user.userName
    const password = document.getElementById("password").value ? document.getElementById("password").value: user.password
    var updateUser = { firstName, lastName, email, password }
    console.log(updateUser);
    const userid = user.userId;
    try {
        const url = 'api/User' + "/" + userid;
        const res = await fetch(url, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(updateUser)
        });
        const response = await res.json();
        alert("update succeed");
        window.location.href = "Products.html"
           
    }
    catch (error) {
        alert("error",error)
    }

}
const checkCode = async () => {
    var strength = {
        0: "Worst",
        1: "Bad",
        2: "Weak",
        3: "Good",
        4: "Strong"
    }
    var meter = document.getElementById('password-strength-meter');
    var text = document.getElementById('password-strength-text');
    const Code = document.getElementById("passwordRegister").value;
    const res = await fetch('api/User/check', {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(Code)
    })
    if (!res.ok)
        throw new Error("error in adding your details to our site")
    const data = await res.json();
    if (data <= 2) alert("your password is weak!! try again")
    meter.value = data;

    if (Code !== "") {
        text.innerHTML = "Strength: " + strength[data.score];
    } else {
        text.innerHTML = "";
    }

}
