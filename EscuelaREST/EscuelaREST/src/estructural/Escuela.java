package estructural;

import java.util.Date;

import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement
public class Escuela {
        private String nombre;
        private String profesor;
        private String estudiante;
        private Date fechaCreacion;
        private String idE;

        public Escuela(String nombre, String profesor, String estudiante, Date fechaCreacion, String idE) {
            this.nombre = nombre;
            this.profesor = profesor;
            this.estudiante = estudiante;   
            this.fechaCreacion = fechaCreacion;
            this.idE = idE;
        }
        public Escuela(){}
        public String getNombre() {
            return nombre;
        }
        
        public void setNombre(String nombre) {
            this.nombre = nombre;
        }

        public String getProfesor() {
            return profesor;
        }

        public void setProfesor(String profesor) {
            this.profesor = profesor;
        }

        public String getEstudiante() {
            return estudiante;
        }

        public void setEstudiante(String estudiante) {
            this.estudiante = estudiante;
        }
        
        public String getIdE() {
            return idE;
        }

        public void setIdE(String idE) {
            this.idE = idE;
        }

        public void setFechaCreacion(Date fechaCreacion) {
            this.fechaCreacion = fechaCreacion;
        }

        public Date getFechaCreacion() {
            return fechaCreacion;
        }
        
    public String toString(){
        String cliXml = "ID:"+getIdE()+"\n"+
        "Nombre"+getNombre()+"\n"+"Profesor: " + getProfesor()
            + "\nFecha: " + getFechaCreacion() + "\nEstudiante: " + getEstudiante();
        return cliXml;
        }
}
