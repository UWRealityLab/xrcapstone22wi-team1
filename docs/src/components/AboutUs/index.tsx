import {
    Container,
    Typography,
    Grid,
    Card,
    CardMedia,
    CardContent,
    CardActions,
    Button,
} from "@mui/material";

const AboutUs = () => {
    return (
        <Container maxWidth="lg">
            <Typography
                variant="h3"
                align="center"
                sx={{ marginBottom: "1em" }}
            >
                About Us
            </Typography>
            <Grid container justifyContent="center" direction="row" spacing={2}>
                {ABOUT.map((person) => (
                    <Grid item xs={12} md={4}>
                        <Card sx={{ maxWidth: 345, margin: "auto" }}>
                            <CardMedia
                                component="img"
                                image={person.image}
                                alt={person.name}
                            />
                            <CardContent>
                                <Typography
                                    gutterBottom
                                    variant="h5"
                                    component="div"
                                >
                                    {person.name}
                                </Typography>
                                <Typography
                                    variant="body2"
                                    color="text.secondary"
                                >
                                    {person.description}
                                </Typography>
                            </CardContent>
                            <CardActions>
                                <a
                                    href={person.link}
                                    target="_blank"
                                    rel="noreferrer"
                                >
                                    <Button size="small">Learn More</Button>
                                </a>
                            </CardActions>
                        </Card>
                    </Grid>
                ))}
            </Grid>
        </Container>
    );
};

const ABOUT = [
    {
        name: "Jolin Tsai",
        image: "./static/images/AboutUs/jolin.jpg",
        description: "Hello! I am a graduating senior majoring in computer science at UW. I didn't have prior experience of VR/AR until this capstone course. I am looking forward to building cool VR/AR application with my team!",
        link: "https://www.linkedin.com/in/yi-lin-tsai",
    },
    {
        name: "Peter Chan",
        image: "./static/images/AboutUs/peter.jpg",
        description: "Hello! I'm a senior computer science student at UW. This is my first time working on VR/AR technology, and I am looking forward to building our first VR application!",
        link: "https://www.linkedin.com/in/chia-hao-chan",
    },
    {
        name: "Justin Huang",
        image: "./static/images/AboutUs/justin.jpg",
        description: "Hi, I am a senior computer science student at UW. I am excited to work on my first VR application in my life!",
        link: "https://linkedin.com/in/cyh0530",
    },
];

export default AboutUs;
