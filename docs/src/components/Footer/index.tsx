import { Box, Container, Typography } from "@mui/material";
import { colors } from "../../constants";
const Footer = () => {
    return (
        <Box sx={{ backgroundColor: colors.purple, textAlign: "center", color: "white", padding: "5em" }}>
            <Container>
                <Typography> Copyright &copy; VR Team 1 2021</Typography>
            </Container>
        </Box>
    );
};

export default Footer;
