package estructural.sw;

import estructural.Escuela;
import estructural.Servicio;

import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;

import java.util.ArrayList;
import java.util.Date;

import javax.jws.Oneway;
import javax.jws.WebMethod;

import javax.jws.WebService;

import javax.ws.rs.DELETE;
import javax.ws.rs.GET;
import javax.ws.rs.PUT;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.QueryParam;

import org.apache.commons.lang.time.DateFormatUtils;


@Path ("/SWEscuelaREST")
public class SWEscuelaREST {
    public SWEscuelaREST() throws Exception {
            super();
            Servicio.cargaDatosDB();
        }
    private Escuela e;
    @PUT
    @Path("addEscuela")
    @Oneway
    @WebMethod
    public void addEscuela(@QueryParam("n")String n,
        @QueryParam("p")String p,@QueryParam("es")String es,@QueryParam("f")Date f, @QueryParam("id")String id  ){
        
        e = new Escuela(n,p,es,f,id);
        Servicio.addEscuela(e);
    }
    
    @GET
    @Produces("application/xml")
    @WebMethod
    public ArrayList<Escuela> getEscuela() {
            return Servicio.getEscuela();
    }
    
    @DELETE
    @Path("eliminarEscuela")
    @Oneway
    @WebMethod
    public void eliminarEscuela(@QueryParam("idEsc")String idEsc) {
            e = null;
            for(Escuela es : Servicio.getEscuela()) {
                if(idEsc.equals(es.getIdE()))
                    e = es;
            }
            if(e != null){
                Servicio.removeEscuela(e);
                Servicio.eliminarDB(idEsc);
            }
        }
    
    @PUT
    @Path("editarSW")
    @Oneway
    @WebMethod
    public void editarSW(@QueryParam("n")String n,
        @QueryParam("p")String p,@QueryParam("es")String es, 
            @QueryParam("id")String id, @QueryParam("f")Date f) {
                Servicio.editar(id, n, p, es, f);
                Servicio.editarDB(id, n, p, es, f);
        }
    @GET
    @Path("buscarSW")
    @WebMethod
    public Escuela buscarSW(@QueryParam("idEsc")String id) {
            try 
            {
                e = Servicio.buscar(id);
            } catch (Exception f) {
                System.out.println(f);
            }
            return e;
        }
}
