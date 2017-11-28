package estructural;


import bd.Conection;

import com.bea.security.xacml.Logger;

import java.sql.ResultSet;

import java.sql.SQLException;

import java.text.SimpleDateFormat;

import java.util.ArrayList;
import java.util.Date;
import java.util.logging.Level;

public class Servicio {
    private static ArrayList<Escuela> escuela = new ArrayList<Escuela>();
        private static Conection con = new Conection();
        private static Escuela e;
        public static void addEscuela(Escuela e) {
            escuela.add(e);
            insertarBD();
        }
        public static void removeEscuela(Escuela e) {
            escuela.remove(e);
        }
        public static void editar(String idE, String n, String p, String est, Date f) {
            for(Escuela es : Servicio.getEscuela()) {
                if(idE.equals(es.getIdE())) {
                    es.setNombre(n);
                    es.setProfesor(p);
                    es.setEstudiante(est);
                    es.setFechaCreacion(f);
                }   
            }
        }

        public static void setEscuela(ArrayList<Escuela> escuela) {
            Servicio.escuela = escuela;
        }

        public static ArrayList<Escuela> getEscuela() {
            return escuela;
        }
        
        public static void insertarBD()
        {
            String insert = "";
            Date escDate = escuela.get(escuela.size() - 1).getFechaCreacion();
            SimpleDateFormat dt = new SimpleDateFormat("dd/MM/yyyy");
            insert = "INSERT INTO escuela VALUES (" + "'"
                +escuela.get(escuela.size() - 1).getIdE()+"','"
                +escuela.get(escuela.size() - 1).getNombre()+"','"
                +escuela.get(escuela.size() - 1).getProfesor()+"','"
                +dt.format(escDate)+"','"   
                +escuela.get(escuela.size() - 1).getEstudiante() + "')";
            System.out.println(insert);
            con.executeUpdateStatement(insert);
            
        }
        
            public static void cargaDatosDB() throws Exception
            {
                ResultSet res = null;
                
                String busca = "SELECT * FROM escuela";
                res = con.executeQueryStatement(busca);
                if(escuela.size()>=1){
                  escuela.clear();
                }
                
                try {
                    while(res.next())
                    {
                       String id = res.getString("idE");
                       String nEscuela = res.getString("nombre");
                       String profesor = res.getString("profesor");
                       Date fecha = res.getDate("fechaCreacion");
                       String estudiante = res.getString("estudiante");
                       e = new Escuela(nEscuela, profesor,estudiante, fecha, id);
                       escuela.add(e);
                       
                    }
                } catch (SQLException ex) {
                    System.out.println("Deu ruim!");
                }
            }
        public static void eliminarDB(String id)
        {
            String busca = "";
            busca = "DELETE from escuela where idE='"+ id +"'";
            System.out.println(busca);
            con.executeUpdateStatement(busca);
        }
        public static void editarDB(String idE, String n, String p, String est, Date f)
        {
            SimpleDateFormat dt = new SimpleDateFormat("dd/MM/yyyy");
            String busca = "";
            busca = "UPDATE escuela set nombre='"+ n
                    +"', profesor='" + p
                    +"', fechaCreacion='" + dt.format(f)
                    +"', estudiante='" + est
                    +"' where idE='" + idE +"'";
            System.out.println(busca);
            con.executeUpdateStatement(busca);
        }
            
        public static Escuela buscar(String id) throws Exception
        {
            e = new Escuela ("","","",null,"");
            int cont = 0;
            for(int i = 0; i < escuela.size(); i++)
            {
                if(id.equals(escuela.get(i).getIdE()))
                {
                    e =  escuela.get(i);
                }else{
                    cont++;
                }
            }
            if(cont == escuela.size())
            {
                cargaDatosDB();
            }

            return e;
        }
}
