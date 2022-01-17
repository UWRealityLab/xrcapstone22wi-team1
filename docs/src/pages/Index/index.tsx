import { Box } from "@mui/material";
import Banner from '../../components/Banner'
import AboutUs from "./AboutUs";


const Index = () => {
    return (
        <Box sx={{ marginBottom: "4em" }}>
            <Banner title="CSE2 Virtual Tour" />
            <AboutUs />
        </Box>
    )
}

export default Index;
