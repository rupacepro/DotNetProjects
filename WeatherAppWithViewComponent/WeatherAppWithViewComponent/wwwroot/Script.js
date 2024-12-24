var button = document.querySelector("#load").addEventListener("click",
    async function() {
        var response = await fetch("load", { method: "GET" });
        var body = await response.text();
        document.querySelector("#result").innerHTML = body;
    })