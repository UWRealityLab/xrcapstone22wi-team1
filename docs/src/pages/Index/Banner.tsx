import { Grid, Container, Typography } from "@mui/material";
import "./banner.css";

const Banner = () => {
    return (
        <div id="banner">
            <div className="overlay"></div>
            <Container>
                <Grid container>
                    <Grid item md={10} lg={8} sx={{ textAlign: "center" }}>
                        <Typography variant="h1" sx={{ fontWeight: 700 }}>
                            CSE2 Virtual Tour
                        </Typography>
                    </Grid>
                </Grid>
            </Container>
        </div>
    );
};

export default Banner;
