//java.ls file
function gethour(id, ssn) {
    $.ajax({
        url: `/WorksFor/editscript?id=${id}&&ssn=${ssn}`,
        success: function (result) {
            console.log(`pno ${id} - ssn ${ssn}`)
            console.log(result);
            var area = document.getElementById("hh");
            area.innerHTML = result;
        }
    });
}