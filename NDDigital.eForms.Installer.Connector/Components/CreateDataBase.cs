using NDDigital.eForms.Installer.Connector.Controls.Manager;
using NDDigital.eForms.Installer.Connector.Controls.SQL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace NDDigital.eForms.Installer.Connector.Components
{
    public class CreateDataBase
    {

        //Connector
        static string DBMGR = ControllerClass.PathFolder.Substring(0, 2) + @"\delete\NDDigital.eForms.DBMGR.exe";
        static string IP = ConnetionSQL.ServidorConnectorSQL;
        static string nameBD = ConnetionSQL.SGBDConnectorSQL;
        static string pathSGBD = "default";
        static string users = ConnetionSQL.UserConnectorSQL;
        static string passwords = ConnetionSQL.SenhaConnectorSQL;
        static string createDB = ControllerClass.PathFolder.Substring(0, 2) + @"\delete\createDB.sql";
        static string createDBObj = ControllerClass.PathFolder.Substring(0, 2) + @"\delete\createDBObj.sql";
        static string SQLCMD = ControllerClass.PathFolder.Substring(0, 2) + @"\delete\SQLCMD.EXE";
        static string SqlSchema = "dbo";

        //ColdExport
        static string DBMGRCold = ControllerClass.PathFolder.Substring(0, 2) + @"\delete\NDDigital.eForms.DBMGR.exe";
        static string IPCold = ConnectionSQLCold.ServidorConnectorCold;
        static string nameBDCold = ConnectionSQLCold.SGBDConnectorCold;
        static string pathSGBDCold = "default";
        static string usersCold = ConnectionSQLCold.UserConnectorCold;
        static string passwordsCold = ConnectionSQLCold.SenhaConnectorCold;
        static string createDBCold = ControllerClass.PathFolder.Substring(0, 2) + @"\delete\createDB.sql";
        static string createDBObjCOLDFILEGENERATOR = ControllerClass.PathFolder.Substring(0, 2) + @"\delete\createDBObjCOLDFILEGENERATOR.sql";
        static string SQLCMDCold = ControllerClass.PathFolder.Substring(0, 2) + @"\delete\SQLCMD.EXE";
        static string SqlSchemaCold = "dbo";

        //Inicia Thread com a ferramenta DBMGR (Responsável por criar o SGDB)
        public CreateDataBase()
        {
            Thread thread = new Thread(ThreadStartTools);
            try
            {
                thread.Start();
                thread.Join();
            }
            catch (Exception)
            {

                throw new Exception();
            }

        }

        //Incia o processo com seus respectivos parametros passados pelo usuario
        static void ThreadStartTools()
        {

            if (!ControllerClass.SGBDCreated)
            {

                Process processo = Process.Start(DBMGR, "2" + " " + IP + " " + nameBD + " " + pathSGBD
                                                                     + " " + users + " " + passwords + " " + createDB + " " + createDBObj
                                                                     + " " + SQLCMD + " " + SqlSchema + " " + "Connector");

                processo.WaitForExit();


            }
            if (!ControllerClass.SGBDCreatedCold)
            {

                Process processoColdExport = Process.Start(DBMGRCold, "2" + " " + IPCold + " " + nameBDCold + " " + pathSGBDCold
                                                    + " " + usersCold + " " + passwordsCold + " " + createDBCold + " " + createDBObjCOLDFILEGENERATOR
                                                    + " " + SQLCMDCold + " " + SqlSchemaCold + " " + "Connector");

                processoColdExport.WaitForExit();

            }
        }
    }
}
