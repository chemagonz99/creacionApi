from typing import Text
import xml.etree.cElementTree as ET

fichero= "C:\\Users\\Chema\\Desktop\\DAM 2º\\Acceso a datos\\creacionApi\\APICalle\\prueba.xml"



xmlvar = ET.parse(fichero)
root= xmlvar.getroot()
input("Press Enter to continue...")


biblioteca=[]

for libro_elem in root.findall(".//libro"):
    titulo= libro_elem.find("titulo").text
    autor= libro_elem.find("autor").text
    fecha= libro_elem.find("fecha").text

    print (f"Titulo del libro: {titulo}, autor: {autor}, fecha: {fecha}")
    biblioteca.append(libro_elem)

    print(biblioteca)

    input("Press Enter to continue...")