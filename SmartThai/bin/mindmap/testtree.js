function idea(title,id,parent){
this.title=title;
this.id=id;
this.parent=parent;
this.ideas={};
this.add=add;
	function add(t,i,p){
	this.ideas["1"+this.id+""+this.count()]= new idea(t,i,this);
	}
this.count=count;
	function count(){
		var ccount = 0;
		for (var k in this.ideas) if (this.ideas.hasOwnProperty(k)) ++ccount;
		return ccount;
	}
}
function test_tree() {
	var textArea = document.getElementById("a");
	var lines = textArea.value.split("\n");
	var current = 0;
	var number = 1;
	point = null;
	var out=new idea(lines[0],1,null); // header
	point = out;
		for(var i = 1;i<lines.length;i++){
		if(lines[i]=="")continue;
		var j=0;
		while(lines[i][j++]=='*');j--;
		if(j-current==1){point.add(lines[i].substr(j),++number,point);continue;}//new node
		if(j-current==2){point = point.ideas["1"+point.id+""+(point.count()-1)];point.add(lines[i].substr(j),++number,point);current++;continue;}//shift current
		while(j-current!=1){point = point.parent ; current--;}
		point.add(lines[i].substr(j),++number,point);//new node
		}
	out["formatVersion"]=2;
	//alert(out.ideass);
	return out;
}
