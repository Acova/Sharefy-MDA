<%@ Page Title="Title" Language="C#" MasterPageFile="Site.Master" CodeBehind="ListCar.aspx.cs" Inherits="Sharefy_MDA.ListCar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="success" class="alert alert-success" role="alert" runat="server">
        Coche listado correctamente.
    </div>

    <div id="fail" class="alert alert-danger" role="alert" runat="server">
        Ya existe un coche con esta matricula.
    </div>

    <div class="searchMenu">
        <div class="row">
            <div class="col">Matrícula</div>
            <div class="col">
                <input id="matriculaInput" type="text" class="form-control" placeholder="Matrícula*"
                       aria-describedby="Button1" runat="server" style="min-width: 100px;"
                       pattern="^[0-9]{1,4}(?!.*(LL|CH))[BCDFGHJKLMNPRSTVWXYZ]{3}"
                       title="Debe ser una matricula española antigua o europea"/>
            </div>
        </div>

        
        <div class="row">
            <div class="col">Datos acerca del vehículo</div>
            <div class="col">
                <input id="datosInput" type="text" class="form-control" placeholder="Datos*"
                       aria-describedby="Button1" runat="server" style="min-width: 100px;"/>
            </div>
        </div>
        <div class="form-group row">
            <div class="col">Condiciones adicionales</div>
            <div class="col">
                <input id="adicionalesInput" type="text" class="form-control" placeholder="Adicionales*"
                       aria-describedby="Button1" runat="server" style="min-width: 100px;"/>
                </div>
            </div>
        
        
         <div class="form-group row">
                    <div class="col">Condiciones predefinidas</div>
                    <div class="col">
                   
                            <fieldset>      
                                <input type="checkbox" id="cond1" value="Cats">Condicion 1<br>      
                                <input type="checkbox" id="cond2" value="Dogs">Condicion 2<br>      
                                <input type="checkbox" id="cond3" value="Birds">Condicion 3<br>
                            </fieldset>      
                        
                        </div>
                    </div>
        
        
        

        <div class="row">
            <div class="col">Fecha inicial de disponibilidad</div>
            <div class="col">
                <input id="InicioInput" type="date" class="form-control"
                       aria-describedby="Button1" runat="server" style="min-width: 100px;"/>
            </div>
        </div>

        <div class="row">
            <div class="col">Fecha final de disponibilidad</div>
            <div class="col">
                <input id="FinInput" type="date" class="form-control"
                       aria-describedby="Button1" runat="server" style="min-width: 100px;"/>
            </div>
        </div>

        <div class="row">
            <div class="col">Imagen</div>
            <div class="col">
                <asp:FileUpload runat="server" ID="flImage" aria-describedby="Button1" style="min-width: 100px;"/>
                
            </div>
        </div>

        <div class="row">
            <div class="col">Ciudad</div>
            <div class="col">
                <input id="ciudadInput" type="text" class="form-control" placeholder="Ciudad*"
                       aria-describedby="Button1" runat="server" style="min-width: 100px;"/>
            </div>
        </div>

        <div class="row">
            <div class="col">Marca</div>
            <div class="col">
                <input id="marcaInput" type="text" class="form-control" placeholder="Marca*"
                       aria-describedby="Button1" runat="server" style="min-width: 100px;"/>
            </div>
        </div>
        <div class="row">
            <div class="col">Modelo</div>
            <div class="col">
                <input id="modeloInput" type="text" class="form-control" placeholder="Modelo*"
                       aria-describedby="Button1" runat="server" style="min-width: 100px;"/>
            </div>
        </div>

        <div class="row">
            <div class="col">Potencia (en CV)</div>
            <div class="col">
                <input id="potenciaInput" type="text" class="form-control" placeholder="Potencia*"
                       aria-describedby="Button1" runat="server" style="min-width: 100px;"/>
            </div>
        </div>

        <div class="row">
            <div class="col">Puertas</div>
            <div class="col">
                <input id="puertasInput" type="text" class="form-control" placeholder="Número de puertas*"
                       aria-describedby="Button1" runat="server" style="min-width: 100px;"/>
            </div>
        </div>

        <div class="row">
            <div class="col">Tipo de coche</div>
            <div class="col">

                <select id="tipoInput" aria-describedby="Button1" style="min-width: 100px;" runat="server">
                    <option value="Coupe">Coupe</option>
                    <option value="Berlina">Berlina</option>
                    <option value="Furgoneta">Furgoneta</option>
                    <option value="Compacto">Compacto</option>
                    <option value="Monovolumen">Monovolumen</option>
                    <option value="Descapotable">Descapotable</option>
                    <option value="Todoterreno">Todoterreno</option>
                </select>

            </div>
        </div>

        <div class="row">
            <div class="col">Precio</div>
            <div class="col">
                <input id="precioInput" type="text" class="form-control" placeholder="Precio*"
                       aria-describedby="Button1" runat="server" style="min-width: 100px;"/>
            </div>
        </div>

        <div class="row">
            <div class="col-auto">
                <asp:Button CssClass="btn btn-primary searchButton" type="button" ID="Button2" Text="Crear" runat="server" OnClick="Create"/>
                <asp:Button CssClass="btn btn-primary searchButton" type="button" ID="Button1" Text="Cancelar" runat="server" OnClick="Cancel"/>
            </div>
        </div>
    </div>
</asp:Content>