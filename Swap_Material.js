var material1 : Material;
var material2 : Material;
var change : boolean = true;
 
function Start() {
        changeMaterial();
}
 
function Update () {
 
}
 
function changeMaterial () {
 
        while(change) {
                yield WaitForSeconds(0.5);
                GetComponent.<Renderer>().material = material1;      
                yield WaitForSeconds(0.5);
                GetComponent.<Renderer>().material = material2;
        }
}
