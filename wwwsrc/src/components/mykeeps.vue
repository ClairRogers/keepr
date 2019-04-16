<template>
  <div class="mykeeps ">
    <h2 v-for="keep in keeps">{{keep.name}}</h2>
  </div>
</template>

<script>
  export default {
    name: "mykeeps",
    props: [],
    data() {
      return {}
    },
    computed: {
      keeps() {
        return this.$store.state.myKeeps
      }
    },
    methods: {},
    components: {}
  }
</script>