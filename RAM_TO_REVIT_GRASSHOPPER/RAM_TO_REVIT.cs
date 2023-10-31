using RAM_TO_REVIT_GRASSHOPPER;
using Grasshopper.Kernel;
using RAMDATAACCESSLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAM_TO_REVIT_GRASSHOPPER
{
    public class GET_FLOOR_TYPE_COUNT : GH_Component
    {

        public GET_FLOOR_TYPE_COUNT() : base("GET_FLOOR_TYPE_COUNT", "GFTC", "Get floor type count", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("C2D7586C-266F-40B4-B4A8-E7510FA67996"); }
        }
        public static GET_FLOOR_TYPE_COUNT Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM file path", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("FloorTypeCount", "C", "Number of floor types in model", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);


            //OPEN
            string FileName = null;
            if (!DA.GetData("FileName", ref FileName)) {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");


            IFloorTypes My_floortypes = IModel.GetFloorTypes();

            int My_floortype_count = My_floortypes.GetCount();
            DA.SetData("FloorTypeCount", My_floortype_count);

            //CLOSE
            IDBI.CloseDatabase();
        }
    }

    public class GET_FLOOR_TYPE_IDS : GH_Component
    {

        public GET_FLOOR_TYPE_IDS() : base("GET_FLOOR_TYPE_IDS", "GFTIDs", "Get the floor type Identifiers", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("03EA8647-7021-459D-AFC8-DD61FAF07D79"); }
        }
        public static GET_FLOOR_TYPE_IDS Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM file path", GH_ParamAccess.item);
            pManager.AddNumberParameter("TotalNumOfFlrTypeInListFormat", "TNFT", "List of floor types", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("FloorTypeID", "FTID", "Floor Type ID", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);


            //OPEN

            string FileName = null;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }

            int TotalNumOfFlrTypeInListFormat = 0;
            if (!DA.GetData("TotalNumOfFlrTypeInListFormat", ref TotalNumOfFlrTypeInListFormat)) 
            {
                return;
            } 
            if (TotalNumOfFlrTypeInListFormat == 0)
            {
                return;
            }

            IDBI.LoadDataBase2(FileName, "1");

            IFloorTypes My_floortypes = IModel.GetFloorTypes();

            IFloorType My_floortype = My_floortypes.GetAt(TotalNumOfFlrTypeInListFormat);
            int My_FloorType_ID = My_floortype.lUID;
            DA.SetData("FloorTypeID", My_FloorType_ID);
            //  
            IDBI.CloseDatabase();
        }
    }


    public class SET_FLOOR_TYPE : GH_Component
    {

        public SET_FLOOR_TYPE() : base("SET_FLOOR_TYPE", "SFT", "Set Floor Type", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("3EE55B6E-4D64-4359-946B-1CAFC86C6187"); }
        }
        public static SET_FLOOR_TYPE Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM File Path", GH_ParamAccess.item);
            pManager.AddTextParameter("FloorTypeName", "FTN", "Floor Type Name", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("FloorTypeID", "FTID", "Floor Type ID", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);

            //OPEN
            string FileName = null;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }

            string FloorTypeName = null;
            if (!DA.GetData("FloorTypeName", ref FloorTypeName))
            {
                return;
            }
            if (FloorTypeName == null || FloorTypeName.Length == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");

            IFloorTypes My_floortypes = IModel.GetFloorTypes();
            IFloorType My_New_floortype = My_floortypes.Add(FloorTypeName);
            int MyFlrTypeID = My_New_floortype.lUID;
            DA.SetData("FloorTypeID", MyFlrTypeID);

            //CLOSE
            IDBI.SaveDatabase();
            IDBI.CloseDatabase();

        }
    }

    public class GET_STORY_COUNT : GH_Component
    {

        public GET_STORY_COUNT() : base("GET_STORY_COUNT", "GSC", "Get Story Count", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("FF24E6AA-6701-4365-BE20-074DAC1EAD1D"); }
        }
        public static GET_FLOOR_TYPE_COUNT Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM File Path", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("My_story_count", "MSC", "My story count", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);

            //OPEN
            string FileName = null;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int My_story_count = My_stories.GetCount();
            DA.SetData("My_story_count", My_story_count);
            //CLOSE           
            IDBI.CloseDatabase();
        }
    }


    public class GET_RAM_COL_CL : GH_Component
    {

        public GET_RAM_COL_CL() : base("GET_STORY_COUNT", "GSC", "Get Story Count", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid("DC579175-5B31-4E92-B8AB-0F1D2B7D8ED3"); }
        }
        public static GET_RAM_COL_CL Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("In_Story_Count", "ISC", "In Story Count", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("ListLine", "LL", "List of Lines", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            int In_Story_Count = 0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("In_Story_Count", ref In_Story_Count))
            {
                return;
            }
            if (In_Story_Count == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int My_story_count = My_stories.GetCount();
            IStory My_Story = My_stories.GetAt(In_Story_Count);
            IColumns My_Columns = My_Story.GetColumns();
            int Column_Count = My_Columns.GetCount();
            SCoordinate P1 = new SCoordinate();
            SCoordinate P2 = new SCoordinate();
            List<Autodesk.DesignScript.Geometry.Line> ListLine = new List<Autodesk.DesignScript.Geometry.Line>();
            //create loop herenthru all count
            //start..end..step
            for (int i = 0; i < Column_Count; i = i + 1)
            {
                My_Story.GetColumns().GetAt(i).GetEndCoordinates(ref P1, ref P2);
                double P1x = P1.dXLoc;
                double P1y = P1.dYLoc;
                double P1z = P1.dZLoc;
                double P2x = P2.dXLoc;
                double P2y = P2.dYLoc;
                double P2z = P2.dZLoc;
                Autodesk.DesignScript.Geometry.Point PD1 =
                    Autodesk.DesignScript.Geometry.Point.ByCoordinates(P1x, P1y, P1z);
                Autodesk.DesignScript.Geometry.Point PD2 =
                    Autodesk.DesignScript.Geometry.Point.ByCoordinates(P2x, P2y, P2z);
                Autodesk.DesignScript.Geometry.Line Dline =
                    Autodesk.DesignScript.Geometry.Line.ByStartPointEndPoint(PD1, PD2);
                ListLine.Add(Dline);
            }
            DA.SetData("ListLine", ListLine);
            //CLOSE           
            IDBI.CloseDatabase();
        }
    }


    public class GET_RAM_COL_SIZE : GH_Component
    {

        public GET_RAM_COL_SIZE() : base("GET_RAM_COL_SIZE", "GRCS", "Get RAM Column Size", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
        }
        public static GET_RAM_COL_SIZE Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("In_Story_Count", "ISC", "In Story Count", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("ListLine", "LL", "List of Lines", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            int In_Story_Count = 0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("In_Story_Count", ref In_Story_Count))
            {
                return;
            }
            if (In_Story_Count == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int My_story_count = My_stories.GetCount();
            IStory My_Story = My_stories.GetAt(In_Story_Count);
            IColumns My_Columns = My_Story.GetColumns();
            int Column_Count = My_Columns.GetCount();

            List<string> ListLine = new List<string>();
            //create loop herenthru all count
            //start..end..step
            for (int i = 0; i < Column_Count; i = i + 1)
            {
                string My_Column_Size = My_Story.GetColumns().GetAt(i).strSectionLabel;
                ListLine.Add(My_Column_Size);
            }
            DA.SetData("ListLine", ListLine);
            //CLOSE           
            IDBI.CloseDatabase();
        }
    }


    public class GET_RAM_COL_ID : GH_Component
    {

        public GET_RAM_COL_ID() : base("GET_RAM_COL_ID", "GRCId", "Get RAM Column ID", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
        }
        public static GET_RAM_COL_ID Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("In_Story_Count", "ISC", "In Story Count", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("ListLine", "LL", "List of Lines", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            int In_Story_Count = 0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("In_Story_Count", ref In_Story_Count))
            {
                return;
            }
            if (In_Story_Count == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int My_story_count = My_stories.GetCount();
            IStory My_Story = My_stories.GetAt(In_Story_Count);
            IColumns My_Columns = My_Story.GetColumns();
            int Column_Count = My_Columns.GetCount();

            List<int> ListLine = new List<int>();
            //create loop herenthru all count
            //start..end..step
            for (int i = 0; i < Column_Count; i = i + 1)
            {
                int My_Column_ID = My_Story.GetColumns().GetAt(i).lUID;
                ListLine.Add(My_Column_ID);
            }
            DA.SetData("ListLine", ListLine);
            //CLOSE           
            IDBI.CloseDatabase();
        }
    }


    public class GET_RAM_COL_Number : GH_Component
    {

        public GET_RAM_COL_Number() : base("GET_RAM_COL_Number", "GRCN", "Get RAM Column Number", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
        }
        public static GET_RAM_COL_Number Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("In_Story_Count", "ISC", "In Story Count", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("ListLine", "LL", "List of Lines", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            int In_Story_Count = 0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("In_Story_Count", ref In_Story_Count))
            {
                return;
            }
            if (In_Story_Count == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int My_story_count = My_stories.GetCount();
            IStory My_Story = My_stories.GetAt(In_Story_Count);
            IColumns My_Columns = My_Story.GetColumns();
            int Column_Count = My_Columns.GetCount();

            List<int> ListLine = new List<int>();
            //create loop herenthru all count
            //start..end..step
            for (int i = 0; i < Column_Count; i = i + 1)
            {
                int My_Column_ID = My_Story.GetColumns().GetAt(i).lLabel; ;
                ListLine.Add(My_Column_ID);
            }
            DA.SetData("ListLine", ListLine);
            //CLOSE           
            IDBI.CloseDatabase();
        }
    }


    public class GET_RAM_COL_IS_GRAV_OR_LATERAL : GH_Component
    {

        public GET_RAM_COL_IS_GRAV_OR_LATERAL() : base("GET_RAM_COL_IS_GRAV_OR_LATERAL", "GRCIGOL", "Get RAM Column is Grav or Lateral", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
        }
        public static GET_RAM_COL_IS_GRAV_OR_LATERAL Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("In_Story_Count", "ISC", "In Story Count", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("ListLine", "LL", "List of Lines", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            int In_Story_Count = 0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("In_Story_Count", ref In_Story_Count))
            {
                return;
            }
            if (In_Story_Count == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int My_story_count = My_stories.GetCount();
            IStory My_Story = My_stories.GetAt(In_Story_Count);
            IColumns My_Columns = My_Story.GetColumns();
            int Column_Count = My_Columns.GetCount();

            List<string> ListLine = new List<string>();
            //create loop herenthru all count
            //start..end..step
            for (int i = 0; i < Column_Count; i = i + 1)
            {
                string My_Column_EFrameType = My_Story.GetColumns().GetAt(i).eFramingType.ToString();
                ListLine.Add(My_Column_EFrameType);
            }
            DA.SetData("ListLine", ListLine);
            //CLOSE           
            IDBI.CloseDatabase();
        }
    }


    public class CREATE_RAM_STEEL_COL : GH_Component
    {

        public CREATE_RAM_STEEL_COL() : base("CREATE_RAM_STEEL_COL", "CRSC", "Create RAM Steel Column", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
        }
        public static CREATE_RAM_STEEL_COL Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter(, , , GH_ParamAccess.item);
            //int FloorIndex, string FileName, double XX, double YY, double ZTop, double ZBot
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter(, , , GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            IDBI.LoadDataBase2(FileName, "1");

            IFloorTypes My_floortypes = IModel.GetFloorTypes();
            IFloorType My_floortype = My_floortypes.GetAt(FloorIndex);
            EMATERIALTYPES My_ColMaterial = EMATERIALTYPES.ESteelMat;

            ILayoutColumn My_LayoutColumn = My_floortype.GetLayoutColumns().Add(My_ColMaterial, XX, YY, ZTop, ZBot);

            //CLOSE 
            IDBI.SaveDatabase();
            IDBI.CloseDatabase();
            int My_New_Col_ID = My_LayoutColumn.lUID;
        }
    }


    public class GET_RAM_BM_CL : GH_Component
    {

        public GET_RAM_BM_CL() : base("GET_RAM_BM_CL", "GRBCL", "Get RAM Beam ", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
        }
        public static GET_RAM_BM_CL Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("In_Story_Count", "ISC", "In Story Count", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("ListLine", "LL", "List of Lines", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            int In_Story_Count = 0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("In_Story_Count", ref In_Story_Count))
            {
                return;
            }
            if (In_Story_Count == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int My_story_count = My_stories.GetCount();
            IStory My_Story = My_stories.GetAt(In_Story_Count);
            IBeams My_Beams = My_Story.GetBeams();
            int Beam_Count = My_Beams.GetCount();
            SCoordinate P1 = new SCoordinate();
            SCoordinate P2 = new SCoordinate();
            List<Autodesk.DesignScript.Geometry.Line> ListLine = new List<Autodesk.DesignScript.Geometry.Line>();
            //create loop herenthru all count
            //start..end..step
            for (int i = 0; i < Beam_Count; i = i + 1)
            {
                My_Story.GetBeams().GetAt(i).GetCoordinates(EBeamCoordLoc.eBeamEnds, ref P1, ref P2);

                double P1x = P1.dXLoc;
                double P1y = P1.dYLoc;
                double P1z = P1.dZLoc;
                double P2x = P2.dXLoc;
                double P2y = P2.dYLoc;
                double P2z = P2.dZLoc;
                Autodesk.DesignScript.Geometry.Point PD1 =
                        Autodesk.DesignScript.Geometry.Point.ByCoordinates(P1x, P1y, P1z);
                Autodesk.DesignScript.Geometry.Point PD2 =
                        Autodesk.DesignScript.Geometry.Point.ByCoordinates(P2x, P2y, P2z);
                Autodesk.DesignScript.Geometry.Line Dline =
                        Autodesk.DesignScript.Geometry.Line.ByStartPointEndPoint(PD1, PD2);
                ListLine.Add(Dline);
            }
            //CLOSE       
            IDBI.CloseDatabase();
        }
    }


    public class GET_RAM_BM_SIZE : GH_Component
    {

        public GET_RAM_BM_SIZE() : base("GET_RAM_BM_SIZE", "GRBS", "Get RAM Beam Size", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
        }
        public static GET_RAM_BM_SIZE Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("In_Story_Count", "ISC", "In Story Count", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("ListLine", "LL", "List of Lines", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            int In_Story_Count = 0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("In_Story_Count", ref In_Story_Count))
            {
                return;
            }
            if (In_Story_Count == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int My_story_count = My_stories.GetCount();
            IStory My_Story = My_stories.GetAt(In_Story_Count);
            IBeams My_Beams = My_Story.GetBeams();
            int Beam_Count = My_Beams.GetCount();
            List<string> ListLine = new List<string>();
            //create loop herenthru all count
            //start..end..step
            for (int i = 0; i < Beam_Count; i = i + 1)
            {
                string My_Beam_Size = My_Story.GetBeams().GetAt(i).strSectionLabel;
                ListLine.Add(My_Beam_Size);
            }
            //CLOSE           
            IDBI.CloseDatabase();
        }
    }

    public class GET_RAM_BM_id : GH_Component
    {

        public GET_RAM_BM_id() : base("GET_RAM_BM_id", "GRBId", "Get RAM Beam ID", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
        }
        public static GET_RAM_BM_id Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("In_Story_Count", "ISC", "In Story Count", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("ListLine", "LL", "List of Lines", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            int In_Story_Count = 0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("In_Story_Count", ref In_Story_Count))
            {
                return;
            }
            if (In_Story_Count == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int My_story_count = My_stories.GetCount();
            IStory My_Story = My_stories.GetAt(In_Story_Count);
            IBeams My_Beams = My_Story.GetBeams();
            int Beam_Count = My_Beams.GetCount();
            List<int> ListLine = new List<int>();
            //create loop herenthru all count
            //start..end..step
            for (int i = 0; i < Beam_Count; i = i + 1)
            {
                int My_Beam_ID = My_Story.GetBeams().GetAt(i).lUID;
                ListLine.Add(My_Beam_ID);
            }
            //CLOSE           
            IDBI.CloseDatabase();
        }
    }

    public class GET_RAM_BM_Number : GH_Component
    {

        public GET_RAM_BM_Number() : base("GET_RAM_BM_Number", "GRBNo", "Get RAM Beam Number", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
        }
        public static GET_RAM_BM_Number Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("In_Story_Count", "ISC", "In Story Count", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("ListLine", "LL", "List of Lines", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            int In_Story_Count = 0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("In_Story_Count", ref In_Story_Count))
            {
                return;
            }
            if (In_Story_Count == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int My_story_count = My_stories.GetCount();
            IStory My_Story = My_stories.GetAt(In_Story_Count);
            IBeams My_Beams = My_Story.GetBeams();
            int Beam_Count = My_Beams.GetCount();
            List<int> ListLine = new List<int>();
            //create loop herenthru all count
            //start..end..step
            for (int i = 0; i < Beam_Count; i = i + 1)
            {
                int My_Beam_ID = My_Story.GetBeams().GetAt(i).lLabel;
                ListLine.Add(My_Beam_ID);
            }
            //CLOSE           
            IDBI.CloseDatabase();
        }
    }

    public class GET_RAM_BM_GRAV_OR_LATERAL : GH_Component
    {

        public GET_RAM_BM_GRAV_OR_LATERAL() : base("GET_RAM_BM_GRAV_OR_LATERAL", "GRBGOL", "Get RAM Beam Grav or Lateral", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
        }
        public static GET_RAM_BM_GRAV_OR_LATERAL Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);
            pManager.AddNumberParameter("In_Story_Count", "ISC", "In Story Count", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            //TODO: Ensure List type for output is correct for EFRAMETYPE
            pManager.AddTextParameter("ListLine", "LL", "List of Lines", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            string FileName = null;
            int In_Story_Count = 0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("In_Story_Count", ref In_Story_Count))
            {
                return;
            }
            if (In_Story_Count == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IStories My_stories = IModel.GetStories();
            int My_story_count = My_stories.GetCount();
            IStory My_Story = My_stories.GetAt(In_Story_Count);
            IBeams My_Beams = My_Story.GetBeams();
            int Beam_Count = My_Beams.GetCount();
            List<EFRAMETYPE> ListLine = new List<EFRAMETYPE>();
            //create loop herenthru all count
            //start..end..step
            for (int i = 0; i < Beam_Count; i = i + 1)
            {
                EFRAMETYPE My_Beam_EFrameType = My_Story.GetBeams().GetAt(i).eFramingType;
                ListLine.Add(My_Beam_EFrameType);
            }
            //CLOSE           
            IDBI.CloseDatabase();
        }
    }


    public class CREATE_RAM_STEEL_BM : GH_Component
    {

        public CREATE_RAM_STEEL_BM() : base("CREATE_RAM_STEEL_BM", "CRSB", "Create RAM Steel Beam", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
        }
        public static CREATE_RAM_STEEL_BM Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter(, , , GH_ParamAccess.item);
        //int FloorIndex, string FileName, double StartSupportX, double StartSupportY,
        //double StartSupportZ, double EndSupportX, double EndSupportY, double EndSupportZ
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter(, , , GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            IDBI.LoadDataBase2(FileName, "1");

            IFloorTypes My_floortypes = IModel.GetFloorTypes();
            IFloorType My_floortype = My_floortypes.GetAt(FloorIndex);
            EMATERIALTYPES My_BmMaterial = EMATERIALTYPES.ESteelMat;

            ILayoutBeam My_LayoutBeam = My_floortype.GetLayoutBeams().Add(My_BmMaterial, StartSupportX, StartSupportY,
                StartSupportZ, EndSupportX, EndSupportY, EndSupportZ);

            //CLOSE 
            IDBI.SaveDatabase();
            IDBI.CloseDatabase();
            int My_New_Beam_ID = My_LayoutBeam.lUID;
        }
    }


    public class CREATE_RAM_STEEL_BRACE : GH_Component
    {

        public CREATE_RAM_STEEL_BRACE() : base("CREATE_RAM_STEEL_BRACE", "CRSB", "Create RAM Steel Brace", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
        }
        public static CREATE_RAM_STEEL_BRACE Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter(, , , GH_ParamAccess.item);
            //int FloorIndex, string FileName, double StartSupportX, double StartSupportY,
            //double StartSupportZ, double EndSupportX, double EndSupportY, double EndSupportZ

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter(, , , GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            //OPEN
            IDBI.LoadDataBase2(FileName, "1");

            IFloorTypes My_floortypes = IModel.GetFloorTypes();
            IFloorType My_floortype = My_floortypes.GetAt(FloorIndex);
            EMATERIALTYPES My_BmMaterial = EMATERIALTYPES.ESteelMat;

            ILayoutHorizBrace My_LayoutBrace = My_floortype.GetLayoutHorizBraces().Add(My_BmMaterial,
                StartSupportX, StartSupportY,
                StartSupportZ, EndSupportX, EndSupportY, EndSupportZ);

            //CLOSE 
            IDBI.SaveDatabase();
            IDBI.CloseDatabase();
            int My_New_Brace_ID = My_LayoutBrace.lUID;
        }
    }


    public class GET_GRID_INFO : GH_Component
    {

        public GET_GRID_INFO() : base("GET_GRID_INFO", "GGI", "Get Grid Info", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
        }
        public static GET_GRID_INFO Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter(, , , GH_ParamAccess.item);

            //Outputs Dictionary type
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            Dictionary<string, object> OutPutPorts = new Dictionary<string, object>();
            //OPEN
            string FileName = null;
            int In_Story_Count = 0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            IModelGrids My_Model_Grids = IModel.GetGridSystems().GetAt(0).GetGrids();
            int My_Grid_Count = My_Model_Grids.GetCount();
            List<double> Grid_Ordinates = new List<double>();
            List<string> Grid_Name = new List<string>();
            List<string> Grid_Axis = new List<string>();

            for (int i = 0; i < My_Grid_Count; i = i + 1)
            {
                //round up and convert grids from inches to feet
                double My_Grid_ORD = Math.Ceiling(My_Model_Grids.GetAt(i).dCoordinate_Angle / 12);
                string My_Model_Grid_Names = My_Model_Grids.GetAt(i).strLabel;
                string My_Model_Grid_Axis = My_Model_Grids.GetAt(i).eAxis.ToString();
                string My_String_Cleanup1 = My_Model_Grid_Axis.Remove(0, 5);
                string My_String_Cleanup2 = My_String_Cleanup1.Remove(1);
                Grid_Ordinates.Add(My_Grid_ORD);
                Grid_Name.Add(My_Model_Grid_Names);
                Grid_Axis.Add(My_String_Cleanup2);
            }
            OutPutPorts.Add("Grid_Name", Grid_Name);
            OutPutPorts.Add("Grid_Ordinates", Grid_Ordinates);
            OutPutPorts.Add("Grid_Axis", Grid_Axis);
            //CLOSE 

            IDBI.CloseDatabase();
        }
    }


    public class CREATE_GRIDS : GH_Component
    {

        public CREATE_GRIDS() : base("CREATE_GRIDS", "CG", "Create Grids", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
        }
        public static CREATE_GRIDS Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter(, , , GH_ParamAccess.item);
            //string FileName, string XGridLabel, double XGridCoord, string YGridLabel, double YGridCoord
        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter(, , , GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            Dictionary<string, object> OutPutPorts = new Dictionary<string, object>();
            //OPEN
            IDBI.LoadDataBase2(FileName, "1");
            IModelGrids My_Model_Grids = IModel.GetGridSystems().GetAt(0).GetGrids();
            //CONVERT TO FEET BY *12 ON INPUT GRID COORDINATE
            IModelGrid MyXIModelGrid = My_Model_Grids.Add(XGridLabel, 
                EGridAxis.eGridXorRadialAxis, XGridCoord*12);
            IModelGrid MyYIModelGrid = My_Model_Grids.Add(YGridLabel, 
                EGridAxis.eGridYorCircularAxis, YGridCoord * 12);
            int My_NewXIModelGridID = MyXIModelGrid.lUID;
            int My_NewYIModelGridID = MyYIModelGrid.lUID;

            OutPutPorts.Add("NewXGrid(ID)", My_NewXIModelGridID);
            OutPutPorts.Add("NewYGrid(ID)", My_NewYIModelGridID);
            //CLOSE 
            IDBI.SaveDatabase();
            IDBI.CloseDatabase();
        }
    }


    public class GET_NUM_LOAD_CASES : GH_Component
    {

        public GET_NUM_LOAD_CASES() : base("GET_NUM_LOAD_CASES", "GNLC", "Get Number of Load Cases", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
        }
        public static GET_NUM_LOAD_CASES Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("FileName", "FN", "RAM Data Path", GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter(, , , GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            RAMDATAACCESSLib.IForces2 IForces2 = (RAMDATAACCESSLib.IForces2)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IForces2_INT);

            //OPEN
            string FileName = null;
            int In_Story_Count = 0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");

            EAnalysisResultType My_EAnalysisResultType = EAnalysisResultType.DefaultResultType;
            int plNumAnalysisCases = 0;

            //these methods work when accessing IFORCES2 so accessing IFORCES2 correctly?
            Type MyIForces2_Type = IForces2.GetType();
            int MyIforces2_Hashcode = IForces2.GetHashCode();
            IForces2.GetNumAnalysisCases(My_EAnalysisResultType, ref plNumAnalysisCases);

            //CLOSE           
            IDBI.CloseDatabase();
        }
    }


    public class GET_GRV_COL_FORCES : GH_Component
    {

        public GET_GRV_COL_FORCES() : base("GET_GRV_COL_FORCES", "GGCF", "Get Gravity Colum Forces", "RAM", "Data")
        {

        }
        public override Guid ComponentGuid
        {
            get { return new Guid(""); }
        }
        public static GET_GRV_COL_FORCES Instance
        {
            get;
            private set;
        }
        protected override void RegisterInputParams(GH_InputParamManager pManager)
        {
            pManager.AddTextParameter(, , , GH_ParamAccess.item);

        }

        protected override void RegisterOutputParams(GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter(, , , GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            RamDataAccess1 RAMDataAccess = new RAMDATAACCESSLib.RamDataAccess1();
            RAMDATAACCESSLib.IDBIO1 IDBI = (RAMDATAACCESSLib.IDBIO1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IDBIO1_INT);
            RAMDATAACCESSLib.IModel IModel = (RAMDATAACCESSLib.IModel)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IModel_INT);
            RAMDATAACCESSLib.IForces1 IForces1 = (RAMDATAACCESSLib.IForces1)
                RAMDataAccess.GetInterfacePointerByEnum(EINTERFACES.IForces_INT);
            Dictionary<string, object> OutPutPorts = new Dictionary<string, object>();
            //OPEN
            string FileName = null;
            int ColumnID= 0;
            if (!DA.GetData("FileName", ref FileName))
            {
                return;
            }
            if (FileName == null || FileName.Length == 0)
            {
                return;
            }
            if (!DA.GetData("ColumnID", ref ColumnID))
            {
                return;
            }
            if (ColumnID == 0)
            {
                return;
            }
            IDBI.LoadDataBase2(FileName, "1");
            double pdDead = 0;
            double pdPosLLRed = 0;
            double pdPosLLNonRed = 0;
            double pdPosLLStorage = 0;
            double pdPosLLRoof = 0;
            double pdNegLLRed = 0;
            double pdNegLLNonRed = 0;
            double pdNegLLStorage = 0;
            double pdNegLLRoof = 0;
            IForces1.GetGrvColForcesForLCase(ColumnID, ref pdDead, ref pdPosLLRed,
                ref pdPosLLNonRed, ref pdPosLLStorage, ref pdPosLLRoof, ref pdNegLLRed,
                ref pdNegLLNonRed, ref pdNegLLStorage, ref pdNegLLRoof);
            IFloorTypes My_floortypes = IModel.GetFloorTypes();
            int My_floortype_count = My_floortypes.GetCount();
            //CLOSE           
            IDBI.CloseDatabase();
            OutPutPorts.Add("pdDead", pdDead); OutPutPorts.Add("pdPosLLRed", pdPosLLRed);
            OutPutPorts.Add("pdPosLLNonRed", pdPosLLNonRed); OutPutPorts.Add("pdPosLLStorage", pdPosLLStorage);
            OutPutPorts.Add("pdPosLLRoof", pdPosLLRoof); OutPutPorts.Add("pdNegLLRed", pdNegLLRed);
            OutPutPorts.Add("pdNegLLNonRed", pdNegLLNonRed); OutPutPorts.Add("pdNegLLStorage", pdNegLLStorage);
            OutPutPorts.Add("pdNegLLRoof", pdNegLLRoof);
        }
    }


}
